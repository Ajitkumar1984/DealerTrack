using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealerTrack.Attributes
{
    public class ValidateFileAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }

            if (file.FileName.EndsWith(".csv"))
            {
                return true;
            }
            return false;
        }
    }
}