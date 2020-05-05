using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medicaldrugstore.Controllers
{
    public class DrugsApiController : ApiController
    {
        public IList<Drug> Get()
        {
            using (StoreContext context = new StoreContext())
            {
                context.Configuration.ProxyCreationEnabled = false;                
                //if (string.IsNullOrEmpty(name))
                //{
                    return context.Drugs.ToList();
                //}
                //else
                //{
                //    return context.Drugs.Where(p => p.DrugName.StartsWith(name)).ToList();
                //}
            }
        }
    }

    public class ProductCategorysApiController : ApiController
    {
        public IList<ProductCategory> Get(string name)
        {
            using (StoreContext context = new StoreContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                if (string.IsNullOrEmpty(name))
                {
                    return context.ProductCategorys.ToList();
                }
                else
                {
                    return context.ProductCategorys.Where(p => p.ProductCategoryName.StartsWith(name)).ToList();
                }
            }
        }
    }

    public class ProductGroupsApiController : ApiController
    {
        public IList<ProductGroup> Get(string name)
        {
            using (StoreContext context = new StoreContext())
            {
                context.Configuration.ProxyCreationEnabled = false;                
                if (string.IsNullOrEmpty(name))
                {
                    return context.ProductGroups.ToList();
                }
                else
                {
                    return context.ProductGroups.Where(p => p.ProductGroupName.StartsWith(name)).ToList();
                }
            }
        }
    }

    public class ProductTypesApiController : ApiController
    {
        public IList<ProductType> Get(string name)
        {
            using (StoreContext context = new StoreContext())
            {
                context.Configuration.ProxyCreationEnabled = false;                
                if (string.IsNullOrEmpty(name))
                {
                    return context.ProductTypes.ToList();
                }
                else
                {
                    return context.ProductTypes.Where(p => p.ProductTypeName.StartsWith(name)).ToList();
                }
            }
        }
    }

    public class ManufacturersApiController : ApiController
    {
        public IList<Manufacturer> Get(string name)
        {
            using (StoreContext context = new StoreContext())
            {
                context.Configuration.ProxyCreationEnabled = false;                
                if (string.IsNullOrEmpty(name))
                {
                    return context.Manufacturers.ToList();
                }
                else
                {
                    return context.Manufacturers.Where(p => p.ManufacturerName.StartsWith(name)).ToList();
                }
            }
        }
    }

    public class SuppliersApiController : ApiController
    {
        public IList<Supplier> Get(string name)
        {
            using (StoreContext context = new StoreContext())
            {
                context.Configuration.ProxyCreationEnabled = false;                
                if (string.IsNullOrEmpty(name))
                {
                    return context.Suppliers.ToList();
                }
                else
                {
                    return context.Suppliers.Where(p => p.SupplierName.StartsWith(name)).ToList();
                }
            }
        }
    }
}