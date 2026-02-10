namespace JobVacancies._01_PostalCodes
{
    public class PostalCode
    {
        uint id;
        ushort codeNumbers;
        string codeLetters;
        string street;
        uint streetNumberMin;
        uint streetNumberMax;
        
        double latitude;
        double longitude;

        public PostalCode(
            uint id, 
            ushort codeNumbers, 
            string codeLetters, 
            string street, 
            uint streetNumberMin, 
            uint streetNumberMax, 
            double latitude, 
            double longitude)
        {
            this.id = id;
            this.codeNumbers = codeNumbers;
            this.codeLetters = codeLetters;
            this.street = street;
            this.streetNumberMin = streetNumberMin;
            this.streetNumberMax = streetNumberMax;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
