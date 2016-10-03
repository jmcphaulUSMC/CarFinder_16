using CarFinder_16.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarFinder_16.Controllers
{
    /// <summary>
    /// Route
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("api/Cars")]
    public class CarsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Route("Years")]

        public async Task<List<string>> GetYears()
        {
            return await db.GetYears();
        }

        [Route("Makes")]
        public async Task<List<string>> GetAllMakes(string _year)
        {
            return await db.GetMakes(_year);
        }

        [Route("Model")]
        public async Task<List<string>> GetAllCarModels(string _year, string _make)
        {
            return await db.GetModels(_year, _make);
        }


        [Route("GetTrim")]
        public async Task<List<string>> GetAllTrim(string _year, string _make, string _model_name)
        {
            return await db.GetTrim(_year, _make, _model_name);
        }

        [Route("GetCar")]
        public async Task<List<Cars>> GetCar(string _year, string _make, string _model_name, string _model_trim)
        {
            return await db.GetCar(_year, _make, _model_name, _model_trim);
        }
        


        [Route("Car")]
        public async Task<IHttpActionResult> getCarData(string year = "", string make = "", string model = "", string trim = "")
        {
            HttpResponseMessage response;
            var content = "";
            var singleCar = await GetCar(year, make, model, trim);
            var car = new CarViewModel
            {
                Car = singleCar.FirstOrDefault(),
                Recalls = content,
                Image = ""
            };


            //Get recall Data
            //string result1 = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.nhtsa.gov/");
                try
                {
                    response = await client.GetAsync("webapi/api/Recalls/vehicle/modelyear/" + year + "/make/"
                        + make + "/model/" + model.ToLower() + "?format=json");
                    content = await response.Content.ReadAsStringAsync();
                    car.Recalls = JsonConvert.DeserializeObject(content);
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }



            //////////////////////////////   My Bing Search   //////////////////////////////////////////////////////////

            string query = year + " " + make + " " + model + " " + trim;

            string rootUri = "https://api.datamarket.azure.com/Bing/Search";

            var bingContainer = new Bing.BingSearchContainer(new Uri(rootUri));

            var accountKey = ConfigurationManager.AppSettings["BingSearchKey"];

            bingContainer.Credentials = new NetworkCredential(accountKey, accountKey);


            var imageQuery = bingContainer.Image(query, null, null, null, null, null, null);

            var imageResults = imageQuery.Execute().ToList();


            car.Image = imageResults.First().MediaUrl;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            return Ok(car);

        }

       
    }
}
