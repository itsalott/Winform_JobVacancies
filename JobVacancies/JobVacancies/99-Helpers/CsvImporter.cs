using System.Globalization;
using System.IO;
using System.Linq;
using JobVacancies._01_PostalCodes;
using JobVacancies._03_Jobs;

namespace JobVacancies
{
    public static class CsvImporter
    {
        private const char SEPARATOR = ',';

        public static PostalCode[] ImportPostalCodesFromCsv(string filePath, bool includesHeader, char separator = SEPARATOR)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Could not find file at path {filePath}!");

            string[] data;
            if (includesHeader)
                data = File.ReadAllLines(filePath).Skip(1).ToArray();
            else
                data = File.ReadAllLines(filePath);

            PostalCode[] postalCodes = new PostalCode[data.Length];
            string[] values;
            for (int i = 0; i < data.Length; i++)
            {
                values = SplitCsvLine(data[i], separator);
                
                postalCodes[i] = new PostalCode(
                    //column 0,
                    id: uint.Parse(values[0]),
                    //column 3,
                    codeNumbers: ushort.Parse(values[3]),
                    //column 4,
                    codeLetters: values[4],
                    //column 5,
                    street: values[5],
                    //column 6
                    streetNumberMin: uint.Parse(values[6]),
                    //column 7
                    streetNumberMax: uint.Parse(values[7]),
                    //column 11
                    latitude: double.Parse(values[11], NumberStyles.Number, CultureInfo.InvariantCulture),
                    //column 12
                    longitude: double.Parse(values[12], NumberStyles.Number, CultureInfo.InvariantCulture))
                { };
            }

            return postalCodes;
        }

        public static Job[] ImportJobsFromCsv(string filePath, bool includesHeader, char separator = SEPARATOR)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Could not find file at path {filePath}!");

            string[] data;
            if (includesHeader)
                data = File.ReadAllLines(filePath).Skip(1).ToArray();
            else
                data = File.ReadAllLines(filePath);

            Job[] jobs = new Job[data.Length];
            string[] values;
            
            int offset = 0;
            ushort? postalCodeArea;
            string province;
            string municipality;
            for (int i = 0; i < data.Length; i++)
            {
                values = SplitCsvLine(data[i], separator);
                // column 5
                postalCodeArea = (values[5] == null) ? (ushort?)null : ushort.Parse(values[5].Replace("\"", ""));
                //column 6,
                province = (values[6] == null) ? null : values[6].Replace("\"", "");
                //column 7,
                municipality = (values[7] == null) ? null : values[7].Replace("\"", "");

                if (postalCodeArea == null && municipality == null)
                {
                    // not enough data, skip this job posting.
                    offset++;
                    continue;
                }

                jobs[i - offset] = new Job(postalCodeArea: postalCodeArea, province: province, municipality: municipality) { };
            }

            return jobs.Take(jobs.Length - offset).ToArray();
        }

        private static string[] SplitCsvLine(string line, char separator, char quoteSign = '\"')
        {
            string[] values = line.Split(separator);
            bool inQuotes = false;
            string value;
            int offset = 0;
            
            for (int i = 0; i < values.Length; i++)
            {
                //offset shift
                value = values[i].Trim();
                if (string.IsNullOrEmpty(value) || value == "\"\"")
                {
                    if (inQuotes)
                    {
                        // add offset, so we skip empty entries as well
                        offset++;
                        values[i - offset] += separator;
                    }
                    else
                    {
                        //actual empty values should be preserved
                        values[i - offset] = null;
                    }

                    continue;
                }

                if (offset > 0)
                {
                    //shift the array, so null values stay at the end.
                    values[i - offset] = values[i];
                }

                if (inQuotes)
                {
                    offset++;
                    
                    values[i - offset] += separator + values[i];
                    if (value[value.Length - 1] == quoteSign)
                    {
                        inQuotes = false;
                    }
                    
                    values[i] = null;
                }
                
                if (!inQuotes && value[0] == quoteSign && value[value.Length - 1] != quoteSign)
                {
                    inQuotes = true;
                }
            }

            return values.Take(values.Length - offset).ToArray();
        }
    }
}
