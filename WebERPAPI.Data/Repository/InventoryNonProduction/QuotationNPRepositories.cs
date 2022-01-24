using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.Inventory.Procurement.Quotation;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.GenericRepository;
using System.Data.Entity.Migrations;
using WebERPAPI.Library;

namespace WebERPAPI.Data.Repository.InventoryNonProduction
{
    public class QuotationNPRepositories
    {
        private NonProductionGenericRepository<Inventory_Quotation_Invitations> _quotation = null;
        private NonProductionGenericRepository<Inventory_Quotation_Received> _quotRec = null;

        public QuotationNPRepositories()
        {
            _quotation = new NonProductionGenericRepository<Inventory_Quotation_Invitations>();
            _quotRec = new NonProductionGenericRepository<Inventory_Quotation_Received>();
        }

        public List<InventoryTypes> getUserInventoryTypeList(string EmployeeID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                var employeeID = new SqlParameter("@EmployeeID", EmployeeID);
                var inventoryTypeID = new SqlParameter("@InventoryTypeID", "0");

                return db.Database.SqlQuery<InventoryTypes>("getUserInventoryTypeList @EmployeeID, @InventoryTypeID", employeeID, inventoryTypeID).ToList();
            }
        }

        public List<UserMainGroup> getUserMainGroupList(string EmployeeID, int InventoryTypeID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                var employeeID = new SqlParameter("@EmployeeID", EmployeeID);
                var inventoryTypeID = new SqlParameter("@InventoryTypeID", InventoryTypeID);

                return db.Database.SqlQuery<UserMainGroup>("getUserInventoryTypeList @EmployeeID, @InventoryTypeID", employeeID, inventoryTypeID).ToList();
            }
        }

        public List<RequisitionSuppliersNP> getRequisitionSuppliersNP(int RequisitionID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var requisitionID = new SqlParameter("@RequisitionID", RequisitionID);

                return db.Database.SqlQuery<RequisitionSuppliersNP>("getRequisitionSuppliersNP @RequisitionID", requisitionID).ToList();
            }
        }

        public List<RequisitionNPPending> getRequisitionNPPending(int empid)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var EmpID = new SqlParameter("@EmpID", empid);
                var data = db.Database.SqlQuery<RequisitionNPPending>("getRequisitionNPPending @EmpID", EmpID).ToList();
                return data;
            }
        }

        // QUOTATION INVITATION

        public Inventory_Quotation_Invitations saveQuotation(CommonDataEntryClass Quotation)
        {
            Inventory_Quotation_Invitations invitation = new Inventory_Quotation_Invitations();
            List<QuotationInvitationSendDetails> quotationItems = JSONSerialize.getJSON<QuotationInvitationSendDetails>(Quotation.Data);

            int itemID = quotationItems[0].ItemID;
            Inventory_Items item = new ProcurementGenericRepository<Inventory_Items>().Find(i => i.ID == itemID).FirstOrDefault();
            Inventory_Item_SubGroup subGroup = new ProcurementGenericRepository<Inventory_Item_SubGroup>().Find(s => s.ID == item.SubGroupId && s.IsActive == true).FirstOrDefault();
            Inventory_Item_MainGroup mainGroup = new ProcurementGenericRepository<Inventory_Item_MainGroup>().Find(m => m.ID == subGroup.MainGroupID && m.IsActive == true).FirstOrDefault();

            string quotationCode = "";

            if (mainGroup.GroupName == "Gift")
            {
                quotationCode = getNewQuotationCode("GIFT");
            }
            else if (mainGroup.GroupName == "Printing")
            {
                quotationCode = getNewQuotationCode("PPM");
            }
            else
            {
                quotationCode = getNewQuotationCode("0");
            }

            if (string.IsNullOrEmpty(quotationCode))
            {
                throw new Exception("Failed to generate quotation code. Please try again.");
            }

            invitation.MainGroupID = Quotation.TypeID;
            invitation.QuotationCode = quotationCode;
            invitation.LastReceiveDate = Quotation.Date;
            invitation.Remarks = Quotation.Remarks;
            invitation.CreatedByID = Quotation.EmployeeCode;
            invitation.CreatedOn = DateTime.Now;
            return new NonProductionGenericRepository<Inventory_Quotation_Invitations>().Insert(invitation);
        }

        private string getNewQuotationCode(string type)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                if (type != "GIFT" && type != "PPM")
                {
                    int count = 0;
                    string quotationCode = "";
                    DateTime monthFirstDate = DateTime.Now.AddDays(-(DateTime.Now.Day));

                    int quotationNo = db.Inventory_Quotation_Invitations.Where(q => q.CreatedOn >= monthFirstDate).Count();
                    quotationNo++;

                    while (count < 999)
                    {
                        quotationCode = "QT-" + DateTime.Now.ToString("YYMM") + quotationCode;

                        if (quotationNo < 10) quotationCode = "QNP-" + DateTime.Now.ToString("yyMM") + "000" + quotationNo.ToString();
                        else if (quotationNo < 100) quotationCode = "QNP-" + DateTime.Now.ToString("yyMM") + "00" + quotationNo.ToString();
                        else if (quotationNo < 1000) quotationCode = "QNP-" + DateTime.Now.ToString("yyMM") + "0" + quotationNo.ToString();
                        else quotationCode = "QNP-" + DateTime.Now.ToString("yyMM") + quotationNo.ToString();
                        if (db.Inventory_Quotation_Invitations.Where(i => i.QuotationCode == quotationCode).FirstOrDefault() == null) return quotationCode;
                        quotationNo++;
                        count++;
                    }
                    return quotationCode;
                }
                else
                {
                    int count = 0;
                    string quotationCode = "";
                    DateTime monthFirstDate = DateTime.Now.AddDays(-(DateTime.Now.Day));

                    int quotationNo = db.Inventory_Quotation_Invitations.Where(q => q.CreatedOn >= monthFirstDate && q.QuotationCode.Contains(type)).Count();
                    quotationNo++;

                    while (count < 999)
                    {
                        quotationCode = "QT-" + DateTime.Now.ToString("YYMM") + quotationCode;

                        if (quotationNo < 10) quotationCode = "LPL-" + DateTime.Now.ToString("yyMM") + "000" + quotationNo.ToString() + type;
                        else if (quotationNo < 100) quotationCode = "LPL-" + DateTime.Now.ToString("yyMM") + "00" + quotationNo.ToString() + type;
                        else if (quotationNo < 1000) quotationCode = "LPL-" + DateTime.Now.ToString("yyMM") + "0" + quotationNo.ToString() + type;
                        else quotationCode = "LPL-" + DateTime.Now.ToString("yyMM") + quotationNo.ToString() + type;

                        if (db.Inventory_Quotation_Invitations.Where(i => i.QuotationCode == quotationCode).FirstOrDefault() == null) return quotationCode;

                        quotationNo++;
                        count++;
                    }
                    return quotationCode;
                }
            }
        }

        public Boolean saveQuotationInvitationDetails(int QuotationID, QuotationInvitationSendDetails QDetails)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Quotation_Invitation_Details iqi = new Inventory_Quotation_Invitation_Details();

                iqi.QuotationID = QuotationID;
                iqi.RequisitionID = QDetails.RequisitionID;
                iqi.ItemID = QDetails.ItemID;
                iqi.SupplierCode = QDetails.SupplierCode;
                iqi.ManufacturerCode = QDetails.ManufacturerCode;

                iqi.Quantity = QDetails.Quantity;
                iqi.CreatedOn = DateTime.Now;

                db.Inventory_Quotation_Invitation_Details.Add(iqi);
                db.SaveChanges();

                return true;
            }
        }

        public Inventory_Quotation_Invitations cancelQuotation(CommonDataEntryClass Data)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Quotation_Invitations quotation = db.Inventory_Quotation_Invitations.FirstOrDefault(q => q.ID == Data.ID);

                if (quotation != null)
                {
                    quotation.IsCanceled = true;

                    quotation.ReasonToCanceled = Data.Remarks;
                    quotation.CanceledBy = Data.EmployeeCode;
                    quotation.CanceledOn = DateTime.Now;

                    db.SaveChanges();

                    return quotation;
                }

                return null;
            }
        }

        public Inventory_Quotation_Invitations getActiveExistingQuotation(int RequisitionID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Quotation_Invitation_Details quotationDetials = db.Inventory_Quotation_Invitation_Details.Where(q => q.RequisitionID == RequisitionID).OrderByDescending(c => c.ID).FirstOrDefault();

                if (quotationDetials != null) return db.Inventory_Quotation_Invitations.FirstOrDefault(q => q.ID == quotationDetials.QuotationID && (q.IsCanceled == false || q.IsCanceled == null));
                return null;
            }
        }

        public List<QuotationsNonProduction> getQuotationsNonProduction(int empid, int ActionGroupID)
        {
            var EmpID = new SqlParameter("@EmpID", empid);
            var actionID = new SqlParameter("@ActionGroupID", ActionGroupID);
            var data = new ProcurementGenericRepository<QuotationsNonProduction>().FindUsingSP("getQuotationsNonProduction @ActionGroupID", actionID);

            return data;
        }

        public List<QuotationsNonProduction> getQuotationsCancelList(int empid)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var EmpID = new SqlParameter("@EmpID", empid);

                return db.Database.SqlQuery<QuotationsNonProduction>("getQuotationsCancelList @EmpID", EmpID).ToList();
            }
        }

        public List<QuotationItemsNP> getQuotationItemsNP(int QuotationID, string QuotationCode)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var quotationID = new SqlParameter("@QuotationID", QuotationID);
                var quotationCode = new SqlParameter("@QuotationCode", QuotationCode);

                return db.Database.SqlQuery<QuotationItemsNP>("getQuotationItemsNP @QuotationID, @QuotationCode", quotationID, quotationCode).ToList();
            }
        }

        public List<QuotationSuppliersNP> getQuotationSuppliersNP(int QuotationID, string QuotationCode)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var quotationID = new SqlParameter("@QuotationID", QuotationID);
                var quotationCode = new SqlParameter("@QuotationCode", QuotationCode);

                return db.Database.SqlQuery<QuotationSuppliersNP>("getQuotationSuppliersNP @QuotationID, @QuotationCode", quotationID, quotationCode).ToList();
            }
        }

        public List<Inventory_Quotation_Invitation_Details> getQuotationDetails(int QuotationID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                return db.Inventory_Quotation_Invitation_Details.Where(q => q.QuotationID == QuotationID).ToList();
            }
        }

        public List<Bill_PaymentType> getBillPaymentTypes()
        {
            using (InventoryEntities db = new InventoryEntities())
            {
                return db.Bill_PaymentType.Where(q => q.IsActive == true).ToList();
            }
        }

        // QUOTATION RECEIVE

        public Inventory_Quotation_Received receiveQuotation(int QuotationID, CommonDataEntryClass Quotation)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Quotation_Received quotation = new Inventory_Quotation_Received();

                if (Quotation.ActionGroupID == ActionGroup.RECEIVED)
                {
                    quotation.IsReceiveComplete = true;
                    setQuotationReceived(QuotationID);
                }

                quotation.Remarks = Quotation.Remarks;
                quotation.CreatedByID = Quotation.EmployeeCode;
                quotation.CreatedOn = DateTime.Now;

                db.Inventory_Quotation_Received.Add(quotation);
                db.SaveChanges();

                return quotation;
            }
        }

        public Inventory_Quotation_Received updateQuotationReceive(int ReceiveID, int QuotationID, CommonDataEntryClass Quotation)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Quotation_Received quotation = db.Inventory_Quotation_Received.FirstOrDefault(q => q.ID == ReceiveID);

                if (quotation != null)
                {
                    if (Quotation.ActionGroupID == ActionGroup.RECEIVED)
                    {
                        quotation.IsReceiveComplete = true;
                        setQuotationReceived(QuotationID);
                    }

                    if (!string.IsNullOrEmpty(Quotation.Remarks)) quotation.Remarks = Quotation.Remarks;

                    quotation.UpdatedByID = Quotation.EmployeeCode;
                    quotation.UpdatedOn = DateTime.Now;

                    db.SaveChanges();
                }

                return quotation;
            }
        }

        public Inventory_Quotation_Received_OtherCost getOtherCost(int QuotationID, string SuppliCode)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                return db.Inventory_Quotation_Received_OtherCost.Where(i => i.IsActive == true && i.QuotationID == QuotationID && i.SupplierCode == SuppliCode).FirstOrDefault();
            }
        }

        public Inventory_Quotation_Received_OtherCost saveOtherCost(Inventory_Quotation_Received_OtherCost item)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                db.Inventory_Quotation_Received_OtherCost.Add(item);
                db.SaveChanges();
            }

            return item;
        }

        public Inventory_Quotation_Received_OtherCost updateOtherCost(Inventory_Quotation_Received_OtherCost item)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                db.Inventory_Quotation_Received_OtherCost.AddOrUpdate(item);
                db.SaveChanges();
            }

            return item;
        }

        public Boolean saveQuotationReceiveDetails(int ReceiveID, Inventory_Quotation_Received_Details Details, string EmployeeCode)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Quotation_Received_Details qr = new Inventory_Quotation_Received_Details();

                qr.QuotationID = Details.QuotationID;
                qr.ReceiveID = ReceiveID;
                qr.RequisitionID = Details.RequisitionID;
                qr.ItemID = Details.ItemID;
                qr.SupplierCode = Details.SupplierCode;

                qr.ManufacturerCode = Details.ManufacturerCode;
                qr.Quantity = Details.Quantity;
                qr.Rate = Details.Rate;
                qr.CreditDays = Details.CreditDays;
                qr.BillPaymentTypeID = Details.BillPaymentTypeID;
                qr.CurrencyId = Details.BillCurrencyTypeID;
                qr.IsActive = true;

                qr.VendorRemarks = Details.VendorRemarks;
                qr.SupplierSpecification = Details.SupplierSpecification;
                qr.RemarksForSupplierSpec = Details.RemarksForSupplierSpec;
                qr.IsSpecificationMatched = Details.IsSpecificationMatched;


                qr.CreatedByID = EmployeeCode;
                qr.CreatedOn = DateTime.Now;

                db.Inventory_Quotation_Received_Details.Add(qr);
                db.SaveChanges();

                return true;
            }
        }

        public Inventory_Quotation_Received getExistingQuotationReceive(int QuotationID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                Inventory_Quotation_Received_Details qrd = db.Inventory_Quotation_Received_Details.FirstOrDefault(q => q.QuotationID == QuotationID && q.IsActive == true);

                if (qrd != null) return db.Inventory_Quotation_Received.FirstOrDefault(q => q.ID == qrd.ReceiveID);
                return null;
            }
        }

        public Boolean cancelAllReceive(int QuotationID, string EmployeeID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                List<Inventory_Quotation_Received_Details> details = db.Inventory_Quotation_Received_Details.Where(q => q.QuotationID == QuotationID && q.IsActive == true).ToList();

                foreach (Inventory_Quotation_Received_Details qrd in details)
                {
                    if (qrd != null)
                    {
                        qrd.IsActive = false;
                        qrd.UpdatedByID = EmployeeID;
                        qrd.UpdatedOn = DateTime.Now;
                        db.SaveChanges();
                    }
                }

                return true;
            }
        }

        private Boolean setQuotationReceived(int QuotationID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Quotation_Invitations qi = db.Inventory_Quotation_Invitations.FirstOrDefault(q => q.ID == QuotationID && q.IsCanceled != true);
                if (qi != null) qi.IsQuotationReceived = true;
                db.SaveChanges();

                return true;
            }
        }

        public List<Inventory_Quotation_Received_Details> getQuotationReceiveDetails(int QuotationID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Inventory_Quotation_Received_Details.Where(q => q.QuotationID == QuotationID
                    //&& q.RequisitionID == RequisitionID
                    && q.IsActive == true).ToList();
            }
        }

        // Find One
        public Inventory_Quotation_Invitations getInventoryQuotation(int QuotationID)
        {
            return _quotation.FindOne(I => I.ID == QuotationID);
        }

        // UPDATE
        public Inventory_Quotation_Invitations updateInventoryQuotation(int ID, Inventory_Quotation_Invitations Entity)
        {
            //Entity.UpdatedOn = DateTime.Now;
            return _quotation.Update(Entity, I => I.ID == ID);
        }
        //public string getcurrencyByCurrencyId(int? currencyId)
        //{
        //    using (SCMEntities db = new SCMEntities())
        //    {
        //        db.Configuration.LazyLoadingEnabled = false;
        //        var currency = db.Currencies.Where(q => q.ID == currencyId).ToString();
        //        return currency;

        //    }
        //}
        public Currency getcurrencyByCurrencyId(int? currencyId)
        {
            using (SCMEntities db = new SCMEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                Currency qrd = db.Currencies.FirstOrDefault(q => q.ID == currencyId);

                return qrd;
            }
        }
    }
}