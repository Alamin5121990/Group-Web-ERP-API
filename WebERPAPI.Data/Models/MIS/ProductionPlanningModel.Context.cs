//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebERPAPI.Data.Models.MIS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProductionPlanningEntities : DbContext
    {
        public ProductionPlanningEntities()
            : base("name=ProductionPlanningEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Inventory_ProductionPlanning_Master> Inventory_ProductionPlanning_Master { get; set; }
        public virtual DbSet<Inventory_ProductionPlanning_MaterialDetails> Inventory_ProductionPlanning_MaterialDetails { get; set; }
        public virtual DbSet<Inventory_ProductionPlanning_Details> Inventory_ProductionPlanning_Details { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Material_Shortage> Material_Shortage { get; set; }
        public virtual DbSet<Products> Products { get; set; }
    }
}
