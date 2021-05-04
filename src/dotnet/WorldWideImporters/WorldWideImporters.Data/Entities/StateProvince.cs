using System.Collections.Generic;

namespace WorldWideImporters.Data
{
    public class StateProvince
    {
        public int StateProvinceID { get; set; }

        public string StateProvinceCode { get; set; }

        public string StateProvinceName { get; set; }

        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public StateProvince()
        {
            this.Cities = new List<City>();
        }
    }
}