using LabaidMIS.Data.Models.MIS;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class MaterialPurchaseTimeline
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Material_PurchaseTimeline Requisition { get; set; }
        public Material_PurchaseTimeline ComparativeStudy { get; set; }
        public Material_PurchaseTimeline InternalApproval { get; set; }
        public Material_PurchaseTimeline PurchaseOrder { get; set; }
        public Material_PurchaseTimeline GRN { get; set; }
        public Material_PurchaseTimeline GRNApproval { get; set; }
        public Material_PurchaseTimeline QCCheckIn { get; set; }
        public Material_PurchaseTimeline QCCheckOut { get; set; }

        public int ProcessingDays { get; set; }
        public int SCMProcessingDays { get; set; }
        public int FactoryProcessingDays { get; set; }
    }
}