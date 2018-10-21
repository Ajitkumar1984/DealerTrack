using DealerTrack.Attributes;
using DealerTrack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealerTrack.ViewModel
{
    public class VehicleSalesViewModel
    {
        public VehicleSalesViewModel()
        {
          
        }

        [Required(ErrorMessage ="Please select a file to upload.")]
        [DisplayName("Upload Sales Data:")]
        public HttpPostedFileBase File { get; set; }       
        public Dictionary<string, List<VehicleSales>> VehicleSales { get; set; }
    }
}