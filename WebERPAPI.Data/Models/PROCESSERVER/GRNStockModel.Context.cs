//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebERPAPI.Data.Models.PROCESSERVER
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GRNStockEntities : DbContext
    {
        public GRNStockEntities()
            : base("name=ProcurementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Inventory_Stock> Inventory_Stock { get; set; }
        public virtual DbSet<Inventory_GRN_Items> Inventory_GRN_Items { get; set; }
        public virtual DbSet<Inventory_QRN> Inventory_QRN { get; set; }
        public virtual DbSet<Inventory_QRN_Items> Inventory_QRN_Items { get; set; }
        public virtual DbSet<Inventory_GRN> Inventory_GRN { get; set; }
        public virtual DbSet<Inventory_Item_UsageTypes> Inventory_Item_UsageTypes { get; set; }
        public virtual DbSet<Inventory_Stock_ChangeLogs> Inventory_Stock_ChangeLogs { get; set; }
        public virtual DbSet<Inventory_UserStores> Inventory_UserStores { get; set; }
        public virtual DbSet<Inventory_Stock_ChangeTypes> Inventory_Stock_ChangeTypes { get; set; }
        public virtual DbSet<Inventory_Stock_Opening> Inventory_Stock_Opening { get; set; }
        public virtual DbSet<Stockbatch> Stockbatches { get; set; }
        public virtual DbSet<GRNVat> GRNVats { get; set; }
    }
}
