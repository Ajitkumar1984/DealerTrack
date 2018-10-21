using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerTrack.Constant
{
    public class VehicleSalesFileConstant
    {
        public static readonly string DealNumber= "DealNumber";
        public static readonly string CustomerName = "CustomerName";
        public static readonly string DealershipName = "DealershipName";
        public static readonly string Vehicle = "Vehicle";
        public static readonly string Price = "Price";
        public static readonly string Date = "Date";
        public static readonly string OledbConnection = @"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""";
    }
}