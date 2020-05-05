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
    public class SupplierCodeRepetition : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            StoreContext db = new StoreContext();
            string currentValue = value as string;
            foreach (Supplier item in db.Suppliers)
            {
                string dbValue = item.SupplierCode;
                if (currentValue.ToUpper() == dbValue.ToUpper())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
