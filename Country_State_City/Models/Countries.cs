using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Country_State_City.Models
{
    public class Countries
    {
        public string name { get; set; }
        public string alpha2Code { get; set; }
        public string capital { get; set; }
        public string population { get; set; }
        public string demonym { get; set; }
        public string subregion { get; set; }
        public string region { get; set; }
    }
    public class CountryViewModel
    {
        public List<Countries> countriesList { get; set; }
        public List<CountryDetails> countryDetails { get; set; }

    }

    public class CountryDetails
    {
        public string name { get; set; }
        public string capital { get; set; }
        public string population { get; set; }
        public string flag { get; set; }


    }
}