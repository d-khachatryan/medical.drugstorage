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
    public class DrugNameRepetitionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            StoreContext db = new StoreContext();
            string currentValue = value as string;
            foreach (Drug item in db.Drugs)
            {
                string dbValue = item.DrugName;
                if (currentValue.ToUpper() == dbValue.ToUpper())
                {
                    return false;
                }
            }
            return true;
        }
    }
}