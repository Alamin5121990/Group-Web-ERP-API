﻿//------------------------------------------------------------------------------
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
    
    public partial class NonProductionCSEntities : DbContext
    {
        public NonProductionCSEntities()
            : base("name=NonProductionCSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bill_PaymentType> Bill_PaymentType { get; set; }
        public virtual DbSet<Inventory_Purchase_Order_Detail> Inventory_Purchase_Order_Detail { get; set; }
        public virtual DbSet<Inventory_Quotation_Invitation_Details> Inventory_Quotation_Invitation_Details { get; set; }
        public virtual DbSet<Inventory_Purchase_Orders> Inventory_Purchase_Orders { get; set; }
        public virtual DbSet<Inventory_Requisition_AdvancePaid> Inventory_Requisition_AdvancePaid { get; set; }
        public virtual DbSet<Inventory_Quotation_Invitations> Inventory_Quotation_Invitations { get; set; }
        public virtual DbSet<Inventory_Spot_Purchase> Inventory_Spot_Purchase { get; set; }
        public virtual DbSet<Inventory_Spot_Purchase_Details> Inventory_Spot_Purchase_Details { get; set; }
        public virtual DbSet<Inventory_Requisition_Item_Specifications> Inventory_Requisition_Item_Specifications { get; set; }
        public virtual DbSet<Inventory_Quotation_Received_OtherCost> Inventory_Quotation_Received_OtherCost { get; set; }
        public virtual DbSet<Inventory_Purchase_Order_AdvancePaid> Inventory_Purchase_Order_AdvancePaid { get; set; }
        public virtual DbSet<CheckCancelledList> CheckCancelledLists { get; set; }
        public virtual DbSet<Inventory_Quotation_Received> Inventory_Quotation_Received { get; set; }
        public virtual DbSet<Inventory_Quotation_Received_Details> Inventory_Quotation_Received_Details { get; set; }
        public virtual DbSet<Inventory_Comparative_Study_Details> Inventory_Comparative_Study_Details { get; set; }
        public virtual DbSet<Inventory_Comparative_Study> Inventory_Comparative_Study { get; set; }
    }
}
