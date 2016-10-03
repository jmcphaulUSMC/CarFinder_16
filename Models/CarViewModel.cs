using CarFinder_16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarFinder_16.Models
{
    public class CarViewModel
    {
        public Cars Car { get; set; }
        public dynamic Recalls { get; set; }
        public string Image { get; set; }
    }
}