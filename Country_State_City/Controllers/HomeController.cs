using Country_State_City.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Country_State_City.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> About()
        {
            List<Countries> countryInfo = new List<Countries>();
            using (var client = new HttpClient())
            {
                string Baseurl = "http://192.168.95.1:5555/";
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://restcountries.eu/rest/v2/all");

                //HTTP GET
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    countryInfo = JsonConvert.DeserializeObject<List<Countries>>(EmpResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            ViewBag.Message = "Manohar Calling API here";

            var model = new CountryViewModel
            {
                countriesList = countryInfo,
            };

            return View(model);
        }

        public async System.Threading.Tasks.Task<ActionResult> DetailsByCountryName(string countryName)
        {
            List<CountryDetails> countryInfo = new List<CountryDetails>();
            using (var client = new HttpClient())
            {
                string Baseurl = "http://192.168.95.1:5555/";
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "https://restcountries.eu/rest/v2/name/" + countryName;
                HttpResponseMessage Res = await client.GetAsync(url);


                //HTTP GET
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    countryInfo = JsonConvert.DeserializeObject<List<CountryDetails>>(EmpResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            var model = new CountryViewModel
            {
                countryDetails = countryInfo,
            };

            ViewBag.Message = "Your contact page.";

            return View("~/Views/Home/CountryDetails.cshtml", model);
        }

        public async System.Threading.Tasks.Task<ActionResult> DetailsByRegionName(string regionName)
        {
            List<CountryDetails> countryInfo = new List<CountryDetails>();
            using (var client = new HttpClient())
            {
                string Baseurl = "http://192.168.95.1:5555/";
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "https://restcountries.eu/rest/v2/region/" + regionName;
                HttpResponseMessage Res = await client.GetAsync(url);


                //HTTP GET
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    countryInfo = JsonConvert.DeserializeObject<List<CountryDetails>>(EmpResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            var model = new CountryViewModel
            {
                countryDetails = countryInfo,
            };

            ViewBag.Message = "Your contact page.";

            return View("~/Views/Home/CountryDetails.cshtml", model);
        }
    }
}