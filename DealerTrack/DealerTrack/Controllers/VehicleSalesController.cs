using DealerTrack.BusinessLogic;
using DealerTrack.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealerTrackSETest.Controllers
{
    public class VehicleSalesController : Controller
    {
        private readonly IVehicleSalesInformation _VehicleSalesInformation;
        public VehicleSalesController(VehicleSalesInformation vehicleSalesInformation)
        {
            _VehicleSalesInformation = vehicleSalesInformation;
        }
        // GET: VehiclsSales
        public ActionResult Index()
        {
            var model = new VehicleSalesViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(VehicleSalesViewModel VehicleSales)
        {
            var file = VehicleSales.File;
            var model = new VehicleSalesViewModel();
            if (file != null)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"),Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    var vehiclesalesdetails=  _VehicleSalesInformation.ReadSalesInformation(path).GroupBy(o => o.Vehicle)
                        .OrderByDescending(g => g.Count())
                                                .ToDictionary(g => g.Key, g => g.ToList());
                                         

                       ModelState.AddModelError("File uploaded successfully","");
                   // model.File = new HttpPostedFileBase(); ;
                    model.VehicleSales = vehiclesalesdetails;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    ModelState.AddModelError("ERROR:", ex.Message.ToString());
                }
            else
            {
              //  ViewBag.Message = "You have not specified a file.";
                ModelState.AddModelError("ERROR:", "You have not specified a file");
            }
            return View("Index",model);
        }
    }
}