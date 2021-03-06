//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabaidERP.Data.MIS_Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MISEntities : DbContext
    {
        public MISEntities()
            : base("name=MISEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BrandWiseYearlyComparison> BrandWiseYearlyComparisons { get; set; }
        public virtual DbSet<ReportColumnType> ReportColumnTypes { get; set; }
        public virtual DbSet<ReportDurationType> ReportDurationTypes { get; set; }
        public virtual DbSet<ProductWiseYearlyComparison> ProductWiseYearlyComparisons { get; set; }
        public virtual DbSet<ZoneWiseSale> ZoneWiseSales { get; set; }
        public virtual DbSet<SalesTarget> SalesTargets { get; set; }
        public virtual DbSet<LocationWiseSale> LocationWiseSales { get; set; }
        public virtual DbSet<SyncEventLog> SyncEventLogs { get; set; }
        public virtual DbSet<BOMMaster> BOMMasters { get; set; }
        public virtual DbSet<DepotAndSalesLocationMapping> DepotAndSalesLocationMappings { get; set; }
        public virtual DbSet<LocationType> LocationTypes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<AreaMaster> AreaMasters { get; set; }
        public virtual DbSet<OAMaster> OAMasters { get; set; }
        public virtual DbSet<RegionMaster> RegionMasters { get; set; }
        public virtual DbSet<ZoneMaster> ZoneMasters { get; set; }
        public virtual DbSet<TerritoryMaster> TerritoryMasters { get; set; }
    }
}
