using System;
using System.IO;

namespace JobVacancies._99_Helpers
{
    public static class ProjectRootPath
    {

        // This will get the current WORKING directory (i.e. \bin\Debug)
        static readonly string workingDirectory = Environment.CurrentDirectory;

        /// <summary>
        /// Returns the project root folder
        /// </summary>
        public static string Value {
            get
            {
                if (_value == null)
                    _value = CalculateProjectRootPath();

                return _value;
            }
        }

        private static string _value;

        private static string CalculateProjectRootPath()
        {
            return Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        }
    }
}
