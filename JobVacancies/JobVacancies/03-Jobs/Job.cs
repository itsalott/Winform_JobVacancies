namespace JobVacancies._03_Jobs
{
    public class Job
    {
        // presumably we'll need more data, but we should at least
        // be able to get some location from these datapoints

        ushort? postalCodeArea;
        string province;
        string municipality;

        public Job(
            ushort? postalCodeArea, 
            string province = null, 
            string municipality = null)
        {
            this.postalCodeArea = postalCodeArea;
            this.province = province;
            this.municipality = municipality;
        }
    }
}
