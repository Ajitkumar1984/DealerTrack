using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using DealerTrack.Constant;
using DealerTrack.Models;


namespace DealerTrack.BusinessLogic
{
    public class VehicleSalesInformation : IVehicleSalesInformation
    {
       

        public IEnumerable<VehicleSales> ReadSalesInformation(string path)
        {
            List<VehicleSales> vehicleSales = null;
            try
            {
                string lines = File.ReadLines(path).First();
                if (ValidateCSVStructure(lines))
                {
                    vehicleSales = (from DataRow row in ConvertCSVtoDataTable(path).Rows
                                    select new VehicleSales
                                    {
                                        DealNumber = Convert.ToInt32(row["DealNumber"].ToString()),
                                        CustomerName = row["CustomerName"].ToString(),
                                        DealershipName = row["DealershipName"].ToString(),
                                        Vehicle = row["Vehicle"].ToString(),
                                        Price = row["price"].ToString(),
                                        Date = Convert.ToDateTime(row["Date"].ToString())

                                    }).ToList();
                }
            }
            catch (Exception ex)
            {

                vehicleSales = new List<VehicleSales>();
            }
            

            return vehicleSales;
        }

        private bool ValidateCSVStructure(string lines)
        {
            var headers = lines.Split(',');
            if (headers.Count() != 6)
                return false;
            if (string.Compare(headers[0].ToString(), VehicleSalesFileConstant.DealNumber, true)==1)
                return false;
            if (string.Compare(headers[1].ToString(), VehicleSalesFileConstant.CustomerName, true) == 1)
                return false;
            if (string.Compare(headers[2].ToString(), VehicleSalesFileConstant.DealershipName, true) == 1)
                return false;
            if (string.Compare(headers[3].ToString(), VehicleSalesFileConstant.Vehicle, true) == 1)
                return false;
            if (string.Compare(headers[4].ToString(),VehicleSalesFileConstant.Price, true) == 1)
                return false;
            if (string.Compare(headers[5].ToString(), VehicleSalesFileConstant.Date, true) == 1)
                return false;


            return true;

        }
        private  DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            var ds = new DataSet("CSV File");
            FileInfo file = new FileInfo(strFilePath);
            var connString = string.Format(VehicleSalesFileConstant.OledbConnection, Path.GetDirectoryName(strFilePath));
            using (var conn = new OleDbConnection(connString))
            {
                var query = "SELECT * FROM [" + Path.GetFileName(file.Name) + "]";
                using (var adapter = new OleDbDataAdapter(query, conn))
                {                   
                    adapter.Fill(ds,"VehicleSales");
                }
            }
           
            return ds.Tables[0];
        }
       
    }
}