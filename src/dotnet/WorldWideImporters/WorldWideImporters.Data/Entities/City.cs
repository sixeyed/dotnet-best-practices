namespace WorldWideImporters.Data
{
    public class City
    {
        public int CityID { get; set; }

        public string CityName { get; set; }

        public long? LatestRecordedPopulation { get; set; }

        public int StateProvinceID { get; set; }

        public virtual StateProvince StateProvince { get; set; }
    }
}