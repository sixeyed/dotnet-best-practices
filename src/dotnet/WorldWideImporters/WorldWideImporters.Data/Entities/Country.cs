using System.Collections.Generic;

namespace WorldWideImporters.Data
{
    public class Country
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public string IsoAlpha3Code { get; set; }

        public virtual ICollection<StateProvince> StateProvinces { get; set; }

        public Country()
        {
            this.StateProvinces = new List<StateProvince>();
        }
    }
}