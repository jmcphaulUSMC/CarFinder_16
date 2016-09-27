using CarFinder_16.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarFinder_16.Controllers
{
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
    }
}
