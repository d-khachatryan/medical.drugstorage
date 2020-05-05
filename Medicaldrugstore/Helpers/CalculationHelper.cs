using System;
using System.Linq;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;

namespace Medicaldrugstore.Helpers
{
    public class CalculationHelper
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

        public CalculationHelper(int? productId, int quantity)
        {
            using (var db = new StoreContext())
            {
                Product product = db.Products.Find(productId);
                Drug drug = db.Drugs.Find(product.DrugId);
                DrugClass drugClass = db.DrugClasses.Find(drug.DrugClassId);
                DrugCategory drugCategory = db.DrugCategories.Find(drugClass.DrugCategoryId);

                ItemQuantity = Convert.ToDouble(quantity) / Convert.ToDouble(drugCategory.UnitItemQuantity);
                TotalCost = drug.UnitCost * (Convert.ToDouble(quantity) / Convert.ToDouble(drugCategory.UnitItemQuantity));
                UnitCost = drug.UnitCost;
            }
        }

       
    }
}