using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerTrack.Models
{
    public class VehicleSales
    {
        public VehicleSales()
        {
        }

        public int DealNumber { get; set; }
        public string CustomerName
        { get; set; }
        public string DealershipName { get; set; }

        public string Vehicle
        { get; set; }

        public string Price { get; set; }

        public DateTime Date { get; set; }
    }
}