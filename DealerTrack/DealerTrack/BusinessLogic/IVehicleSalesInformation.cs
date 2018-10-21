using DealerTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerTrack.BusinessLogic
{
   public interface IVehicleSalesInformation
    {

      
        IEnumerable<VehicleSales> ReadSalesInformation(string filename);

    }
}

