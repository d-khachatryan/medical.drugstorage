using System;
using System.Linq;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;

namespace Medicaldrugstore.Helpers
{
    public class DrugCalculationHelper
    {        
        double? totalCost;
        double? unitCost;
        double? itemQuantity;
        
        public double? TotalCost
        {
            get
            {
                return this.totalCost;
            }
            set
            {
                this.totalCost = value;
            }
        }

        public double? UnitCost
        {
            get
            {
                return this.unitCost;
            }
            set
            {
                this.unitCost = value;
            }
        }

        public double? ItemQuantity
        {
            get
            {
                return this.itemQuantity;
            }
            set
            {
                this.itemQuantity = value;
            }
        }

        public DrugCalculationHelper(int? drugClassId, int quantity, double? unitCost)
        {
            using (var db = new StoreContext())
            {                
                DrugClass drugClass = db.DrugClasses.Find(drugClassId);
                DrugCategory drugCategory = db.DrugCategories.Find(drugClass.DrugCategoryId);

                ItemQuantity = Convert.ToDouble(quantity) / Convert.ToDouble(drugCategory.UnitItemQuantity);
                TotalCost = unitCost * (Convert.ToDouble(quantity) / Convert.ToDouble(drugCategory.UnitItemQuantity));
                UnitCost = unitCost;
            }
        }

       
    }
}