using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medicaldrugstore.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Medicaldrugstore.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("DefaultConnection")
        {
        }

        //Tables
        public DbSet<ReplacementBase> ReplacementBases { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugPicture> DrugPictures { get; set; }
        public DbSet<DrugClass> DrugClasses { get; set; }
        public DbSet<DrugSource> DrugSources { get; set; }
        public DbSet<DrugCategory> DrugCategories { get; set; }
        public DbSet<DrugType> DrugTypes { get; set; }
        public DbSet<BaseDocument> BaseDocuments { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Placement> Placements { get; set; }
        public DbSet<PlacementBase> PlacementBases { get; set; }
        public DbSet<JunkBase> JunkBases { get; set; }
        public DbSet<PlacementItemProduct> PlacementItemProducts { get; set; }
        public DbSet<PlacementItem> PlacementItems { get; set; }
        public DbSet<PlacementStatus> PlacementStatuses { get; set; }
        public DbSet<JunkProductStatus> JunkProductStatuses { get; set; }
        public DbSet<JunkConsumptionStatus> JunkConsumptionStatuses { get; set; }
        public DbSet<ReplacementStatus> ReplacementStatuses { get; set; }
        public DbSet<ConsumptionStatus> ConsumptionStatuses { get; set; }
        public DbSet<TransferStatus> TransferStatuses { get; set; }
        public DbSet<RetransferStatus> RetransferStatuses { get; set; }
        public DbSet<JunkProduct> JunkProducts { get; set; }
        public DbSet<JunkConsumption> JunkConsumptions { get; set; }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ConsumptionProduct> ConsumptionProducts { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Retransfer> Retransfers { get; set; }
        public DbSet<DispensingType> DispensingTypes { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<MessageBox> MessageBoxes { get; set; }
        public DbSet<Replacement> Replacements { get; set; }
        public DbSet<ReplacementProduct> ReplacementProducts { get; set; }
        public DbSet<ReplacementProductStorage> ReplacementProductStorages { get; set; }
        //Tables

        //Views
        public DbSet<DrugDetail> DrugDetails { get; set; }
        public DbSet<DrugItem> DrugItems { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<DrugClassDetail> DrugClassDetails { get; set; }
        public DbSet<StorageDetail> StorageDetails { get; set; }
        public DbSet<OrganizationDetail> OrganizationDetails { get; set; }
        public DbSet<PlacementDetail> PlacementDetails { get; set; }
        public DbSet<TransferPlacement> TransferPlacements { get; set; }
        public DbSet<ReplacementDetails> ReplacementDetails { get; set; }
        public DbSet<PlacementItemDetails> PlacementItemDetails { get; set; }
        public DbSet<PlacementItemProductDetails> PlacementItemProductDetails { get; set; }
        public DbSet<TransferDetail> TransferDetails { get; set; }
        public DbSet<RetransferDetails> RetransferDetails { get; set; }
        public DbSet<ConsumptionDetail> ConsumptionDetails { get; set; }
        public DbSet<JunkConsumptionDetail> JunkConsumptionDetails { get; set; }
        public DbSet<JunkProductDetail> JunkProductDetails { get; set; }
        public DbSet<ConsumptionProductDetail> ConsumptionProductDetails { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleItem> UserRoleItems { get; set; }
        public DbSet<UserOrganizationItem> UserOrganizationItems { get; set; }
        public DbSet<UserOrganization> UserOrganizations { get; set; }
        //Views

        //Stored Procedures
        public DbSet<StoreOrganization> StoreOrganizations { get; set; }
        public DbSet<OrganizationStore> OrganizationStores { get; set; }
        public DbSet<StorageStore> StorageStores { get; set; }
        //Stored Procedures


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}

