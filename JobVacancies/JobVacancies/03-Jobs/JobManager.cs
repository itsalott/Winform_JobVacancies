using JobVacancies._01_PostalCodes;
using JobVacancies._99_Helpers;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace JobVacancies._03_Jobs
{
    internal class JobManager
    {
        private const string JOB_POSTING_CSV = @"Data\Jobs\uwv_2017-05-09\uwv_2017-05-09.csv";

        private Job[] jobs;

        public JobManager()
        {
            jobs = CsvImporter.ImportJobsFromCsv(Path.Combine(ProjectRootPath.Value, JOB_POSTING_CSV), false);
        }
    }
}
