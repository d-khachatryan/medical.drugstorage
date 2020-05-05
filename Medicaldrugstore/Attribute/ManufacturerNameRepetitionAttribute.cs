using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicaldrugstore.Controllers;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;


namespace Medicaldrugstore.Attribute
{
    public class ManufacturerNameRepetitionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            StoreContext db = new StoreContext();
            string currentValue = value as string;
            foreach (Manufacturer item in db.Manufacturers)
            {
                string dbValue = item.ManufacturerName;
                if (currentValue.ToUpper() == dbValue.ToUpper())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
