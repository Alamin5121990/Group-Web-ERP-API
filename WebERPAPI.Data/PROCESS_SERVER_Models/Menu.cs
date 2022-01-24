//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabaidERP.Data.PROCESS_SERVER_Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menu
    {
        public int MenuID { get; set; }
        public Nullable<int> ValueMember { get; set; }
        public string DisplayMember { get; set; }
        public Nullable<int> ParentID { get; set; }
        public bool IsVisible { get; set; }
        public Nullable<int> Type { get; set; }
        public bool UDID { get; set; }
        public string Description { get; set; }
        public string FormName { get; set; }
        public string MenuType { get; set; }
        public int MenuSequence { get; set; }
        public string DataType { get; set; }
        public Nullable<int> RestrictionLimit { get; set; }
        public string Assembly { get; set; }
        public string NameSpace { get; set; }
        public string MethodName { get; set; }
        public bool IsAdminOnly { get; set; }
        public string ParameterSQL { get; set; }
        public bool IsSP { get; set; }
        public string ResourcePath { get; set; }
        public string FileName { get; set; }
        public bool AttachReport { get; set; }
        public string DefaultReport { get; set; }
        public string ChartType { get; set; }
        public string ReportSourceName { get; set; }
        public Nullable<bool> CrossTab { get; set; }
        public string ColumnData { get; set; }
        public string LineData { get; set; }
        public string TitleBottom { get; set; }
        public string TitleTop { get; set; }
        public string TitleRight { get; set; }
        public string TitleLeft { get; set; }
        public bool LegendVisible { get; set; }
        public Nullable<int> YExtent { get; set; }
        public Nullable<int> Y2Extent { get; set; }
        public Nullable<int> XExtent { get; set; }
        public Nullable<int> RowLabelsColumn { get; set; }
        public int ReportType { get; set; }
        public string ExcludeColumns { get; set; }
        public bool IsWebMenu { get; set; }
        public string Route { get; set; }
        public bool Transfered { get; set; }
        public bool HOTransfered { get; set; }
        public string Location { get; set; }
        public string MachineNameIP { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}
