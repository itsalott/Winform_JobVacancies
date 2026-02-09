using JobVacancies._99_Helpers;
using System.IO;

namespace JobVacancies._01_PostalCodes
{
    internal class PostalCodeLocationManager
    {
        private const string POSTAL_CODE_LOCATION_CSV = @"Data\Postcodes\postcodetabel.csv";

        private PostalCode[] postalCodes;

        public PostalCodeLocationManager() {
            postalCodes = CsvImporter.ImportPostalCodesFromCsv(Path.Combine(ProjectRootPath.Value, POSTAL_CODE_LOCATION_CSV), true);
        }
    }
}
