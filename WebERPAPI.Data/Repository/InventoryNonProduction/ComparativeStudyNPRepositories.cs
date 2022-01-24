using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement.CS;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.Repository.InventoryNonProduction
{
    public class ComparativeStudyNPRepositories
    {
        private NonProductionGenericRepository<Inventory_Comparative_Study> CSMaster = null;
        private NonProductionGenericRepository<Inventory_Comparative_Study_Details> CSDetails = null;

        public ComparativeStudyNPRepositories()
        {
            CSMaster = new NonProductionGenericRepository<Inventory_Comparative_Study>();
            CSDetails = new NonProductionGenericRepository<Inventory_Comparative_Study_Details>();
        }

        //public string sendComparativeStudyEmail(string EmployeeID, Inventory_Comparative_Study CS, string TemplateFilepath, string Message)
        //{
        //    try
        //    {
        //        MaterialRepositories mRepo = new MaterialRepositories();
        //        UserRepositories repo = new UserRepositories();

        //        string productDescription = "";
        //        int index = 0;
        //        decimal totalAmount = 0, amount = 0;

        //        string emailContent = "";

        //        Scripting.readFile(ref emailContent, TemplateFilepath);

        //        using (SCMEntities db = new SCMEntities())
        //        {
        //            foreach (ComparativeStudyApprovalData item in logs)
        //            {
        //                index++;
        //                Material mat = mRepo.getMaterialDetails(item.MaterialCode);

        //                var CSDetails = getComparativeStudyDetails(item.CSID, item.MaterialCode);

        //                amount = (CSDetails.Quantity.GetValueOrDefault() * CSDetails.Price.GetValueOrDefault());
        //                totalAmount += amount;

        //                productDescription += "<tr>";

        //                productDescription += "<td style='max-width: 50px; text-align: center'>" + index + "</td>";

        //                productDescription += "<td style='max-width: 500px; word-wrap: break-word; text-align: left;'><strong>" + mat.MaterialName + "</strong>";
        //                if (!string.IsNullOrEmpty(mat.ShortSpec)) productDescription += "<br/><br/><br/> Specification: " + mat.ShortSpec + "</td>";

        //                productDescription += "<td style='max-width: 100px; text-align: center'>" + CSDetails.Quantity.GetValueOrDefault().ToString("#,##0") + "</td>";
        //                productDescription += "<td style='max-width: 50px; text-align: center'>" + mat.UOM + "</td>";
        //                productDescription += "<td style='max-width: 100px; text-align: center'>" + CSDetails.Price.GetValueOrDefault().ToString("#,##0") + "</td>";
        //                productDescription += "<td style='max-width: 100px; text-align: center'>" + amount.ToString("#,##0") + "</td>";

        //                productDescription += "</tr>";
        //            }
        //        }

        //        emailContent = emailContent.Replace("[MESSAGE]", Message);

        //        emailContent = emailContent.Replace("[PRODUCT_DESCRIPTION]", productDescription);
        //        emailContent = emailContent.Replace("[TOTAL_AMOUNT]", totalAmount.ToString("#,##0"));

        //        emailContent = emailContent.Replace("[SIGNATURE]", repo.getEmailSignature(EmployeeCode));

        //        return emailContent;
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex;
        //        return "";
        //    }
        //}

        public Inventory_Comparative_Study saveComparativeStudy(Inventory_Comparative_Study newCS)
        {
            string CSCode = getNewComparativeStudyCode();
            if (string.IsNullOrEmpty(CSCode)) throw new Exception("Failed to generate CS code. Please try again.");
            newCS.IsChecked = true;
            newCS.CheckedOn = DateTime.Now;
            newCS.CheckedByID = newCS.CreatedByID;

            newCS.CSCode = CSCode;
            newCS.CreatedOn = DateTime.Now;
            return CSMaster.Insert(newCS);
        }

        public Inventory_Comparative_Study updateComparativeStudy(int CSID, Inventory_Comparative_Study CSData)
        {
            return CSMaster.Update(CSData, p => p.ID == CSID);
        }

        public Boolean saveComparativeStudyDetails(int CSID, ComparativeStudyDetailsNew Details, string EmployeeCode)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Comparative_Study_Details CSD = new Inventory_Comparative_Study_Details();

                CSD.CSID = CSID;
                CSD.RequisitionID = Details.RequisitionID;
                CSD.ItemID = Details.ItemID;
                CSD.SupplierCode = Details.SupplierCode;

                CSD.ManufacturerCode = Details.ManufacturerCode;
                CSD.Quantity = Details.Quantity;
                CSD.Rate = Details.Rate;

                CSD.IsActive = true;

                CSD.CreatedByID = EmployeeCode;
                CSD.CreatedOn = DateTime.Now;

                db.Inventory_Comparative_Study_Details.Add(CSD);
                db.SaveChanges();
                //Inventory Quotation update for bill payment change
                Inventory_Quotation_Received_Details iqrd = new NonProductionGenericRepository<Inventory_Quotation_Received_Details>().Find(i => i.RequisitionID == CSD.RequisitionID && i.ItemID == CSD.ItemID && i.IsActive == true && i.SupplierCode == CSD.SupplierCode && i.Quantity == CSD.Quantity).FirstOrDefault();
                if (iqrd != null)
                {
                    iqrd.BillPaymentTypeID = Details.BillPaymentTypeID;
                    iqrd.CurrencyId = Details.BillCurrencyTypeID;

                    iqrd.CreditDays = Details.CreditDays;
                    iqrd.Rate = Convert.ToDecimal(Details.Rate);
                    iqrd.UpdatedByID = EmployeeCode;
                    iqrd.UpdatedOn = DateTime.Now;
                    new NonProductionGenericRepository<Inventory_Quotation_Received_Details>().Update(iqrd, i => i.ID == iqrd.ID);
                }

                return true;
            }
        }

        public Inventory_Comparative_Study getExistingComparativeStudy(int RequisitionID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                Inventory_Comparative_Study_Details csd = db.Inventory_Comparative_Study_Details.Where(q => q.RequisitionID == RequisitionID && q.IsActive == true)
                        .OrderByDescending(q => q.CreatedOn).FirstOrDefault();

                if (csd != null) return db.Inventory_Comparative_Study.FirstOrDefault(
                        q => q.ID == csd.CSID && (q.IsCanceled == false || q.IsCanceled == null)
                        );
                return null;
            }
        }

        private string getNewComparativeStudyCode()
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                int count = 0;
                string CSCode = "";
                DateTime monthFirstDate = DateTime.Now.AddDays(-(DateTime.Now.Day));

                int csNo = db.Inventory_Comparative_Study.Where(q => q.CreatedOn >= monthFirstDate).Count();
                csNo++;

                while (count < 999)
                {
                    if (csNo < 10) CSCode = "CSN-" + DateTime.Now.ToString("yyMM") + "000" + csNo.ToString();
                    else if (csNo < 100) CSCode = "CSN-" + DateTime.Now.ToString("yyMM") + "00" + csNo.ToString();
                    else if (csNo < 1000) CSCode = "CSN-" + DateTime.Now.ToString("yyMM") + "0" + csNo.ToString();
                    else CSCode = "CSN-" + DateTime.Now.ToString("yyMM") + csNo.ToString();

                    if (db.Inventory_Comparative_Study.Where(i => i.CSCode == CSCode).FirstOrDefault() == null) return CSCode;

                    csNo++;
                    count++;
                }

                return CSCode;
            }
        }

        public Boolean updateQuotationReceiveDetails(ComparativeStudyDetailsNew Details, string EmployeeCode)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Quotation_Received_Details qrd = db.Inventory_Quotation_Received_Details.FirstOrDefault(
                        q => q.QuotationID == Details.QuotationID
                        && q.RequisitionID == Details.RequisitionID
                        && q.ItemID == Details.ItemID
                        && q.SupplierCode == Details.SupplierCode
                        && q.Quantity == Details.Quantity
                        && q.IsActive == true);

                if (qrd != null)
                {
                    qrd.Quantity = Details.Quantity.GetValueOrDefault();
                    qrd.Rate = Details.Rate.GetValueOrDefault();
                    qrd.CreditDays = Details.CreditDays;
                    qrd.BillPaymentTypeID = Details.BillPaymentTypeID;
                    qrd.CurrencyId = Details.BillCurrencyTypeID;

                    qrd.VendorRemarks = Details.VendorRemarks;
                    qrd.UpdatedByID = EmployeeCode;
                    qrd.UpdatedOn = DateTime.Now;

                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }

        public List<ComparativeStudyListNP> getComparativeStudy(int empid, string CSCode, int ActionGroupID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var EmpID = new SqlParameter("@EmpID", empid);
                var cSCode = new SqlParameter("@CSCode", CSCode);
                var actionGroupID = new SqlParameter("@ActionGroupID", ActionGroupID);

                return db.Database.SqlQuery<ComparativeStudyListNP>("getComparativeStudyNP @EmpID, @CSCode, @ActionGroupID", EmpID, cSCode, actionGroupID).ToList();
            }
        }

        public List<ComparativeStudyListNP> getComparativeStudyStatusReport(int empid, int inventoryid)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var EmpID = new SqlParameter("@EmpID", empid);
                var InventoryTypeID = new SqlParameter("@InventoryTypeID", inventoryid);
                return db.Database.SqlQuery<ComparativeStudyListNP>("getComparativeStudyStatusReportNP  @EmpID, @InventoryTypeID", EmpID, InventoryTypeID).ToList();
            }
        }

        public Inventory_Quotation_Invitations getQuotationFromCS(int CSID, string CSCode = "0")
        {
            Inventory_Comparative_Study CS = new NonProductionGenericRepository<Inventory_Comparative_Study>().Find(c => c.CSCode == CSCode).FirstOrDefault();
            Inventory_Comparative_Study_Details csd = new NonProductionGenericRepository<Inventory_Comparative_Study_Details>().Find(c => c.CSID == CS.ID && c.IsActive == true).FirstOrDefault();

            return new NonProductionGenericRepository<Inventory_Quotation_Invitations>().FindUsingSP("getQuotationInvitationNPDetailsByRequisitionID @RequisitionID", new SqlParameter("@RequisitionID", csd.RequisitionID)).FirstOrDefault();
        }

        public Inventory_Comparative_Study getComparativeStudy(int CSID, string CSCode = "0")
        {
            if (CSID == 0) return new NonProductionGenericRepository<Inventory_Comparative_Study>().Find(c => c.CSCode == CSCode).FirstOrDefault();

            return new NonProductionGenericRepository<Inventory_Comparative_Study>().Find(c => c.ID == CSID).FirstOrDefault();
        }

        public List<Inventory_Comparative_Study_Details> getComparativeStudyDetails(int CSID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                return db.Inventory_Comparative_Study_Details.Where(c => c.CSID == CSID && c.IsActive == true).ToList();
            }
        }

        public Inventory_Comparative_Study cancelComparativeStudy(CommonDataEntryClass Data)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                Inventory_Comparative_Study CS = db.Inventory_Comparative_Study.FirstOrDefault(c => c.CSCode == Data.Code);
                if (CS != null)
                {
                    CS.CanceledByID = Data.EmployeeCode;
                    CS.CanceledOn = DateTime.Now;
                    CS.ReasonToCancel = Data.Remarks;
                    CS.IsCanceled = true;

                    db.SaveChanges();
                }

                return CS;
            }
        }

        public List<ComparativeStudySignaturesNP> getComparativeStudySignaturesNP(int CSID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var cSID = new SqlParameter("@CSID", CSID);
                return db.Database.SqlQuery<ComparativeStudySignaturesNP>("getComparativeStudySignaturesNP @CSID", cSID).ToList();
            }
        }

        public Boolean cancelAllExistingCSDetails(int CSID, string EmployeeID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                List<Inventory_Comparative_Study_Details> CSDetails = db.Inventory_Comparative_Study_Details.Where(q => q.CSID == CSID && q.IsActive == true).ToList();

                foreach (Inventory_Comparative_Study_Details csd in CSDetails)
                {
                    if (csd != null)
                    {
                        csd.IsActive = false;
                        csd.UpdatedByID = EmployeeID;
                        csd.UpdatedOn = DateTime.Now;
                        db.SaveChanges();
                    }
                }

                return true;
            }
        }

        public Boolean reviewAndVerifyComparativeStudy(int CSID, CommonDataEntryClass CSData)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Comparative_Study CS = db.Inventory_Comparative_Study.FirstOrDefault(q => q.ID == CSID);
                if (CS != null)
                {
                    if (ActionGroup.REVIEWED == CSData.ActionGroupID)
                    {
                        CS.IsReviewed = true;
                        CS.ReviewedByID = CSData.EmployeeCode;
                        CS.ReviewedOn = DateTime.Now;
                        CS.ReviewRemarks = CSData.Remarks;
                    }
                    else if (ActionGroup.CHECKED == CSData.ActionGroupID)
                    {
                        CS.IsChecked = true;
                        CS.CheckedByID = CSData.EmployeeCode;
                        CS.CheckedOn = DateTime.Now;
                        CS.CheckedRemarks = CSData.Remarks;
                    }
                    else if (ActionGroup.VERIFIED == CSData.ActionGroupID)
                    {
                        CS.IsVerified = true;
                        CS.VerifiedByID = CSData.EmployeeCode;
                        CS.VerifiedOn = DateTime.Now;
                        CS.VerifiedRemarks = CSData.Remarks;
                    }
                    else if (ActionGroup.RECOMMENDED == CSData.ActionGroupID)
                    {
                        CS.IsRecommended = true;
                        CS.RecommendedByID = CSData.EmployeeCode;
                        CS.RecommendedOn = DateTime.Now;
                        CS.RecommendationRemarks = CSData.Remarks;
                    }
                    else if (ActionGroup.APPROVED == CSData.ActionGroupID)
                    {
                        CS.IsManagementApproved = true;
                        CS.ManagementApprovedById = CSData.EmployeeCode;
                        CS.ManagementApprovedOn = DateTime.Now;
                        CS.ManagementApprovalRemarks = CSData.Remarks;
                    }

                    db.SaveChanges();
                }

                return true;
            }
        }

        public Inventory_Comparative_Study getComparativeStudy(int RequisitionID, int ItemID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                Inventory_Comparative_Study_Details CS = db.Inventory_Comparative_Study_Details.FirstOrDefault(
                        p => p.RequisitionID == RequisitionID
                        && p.ItemID == ItemID
                        && p.IsActive == true);

                if (CS != null) return db.Inventory_Comparative_Study.FirstOrDefault(p => p.ID == CS.CSID && (p.IsCanceled == false || p.IsCanceled == null));
                else return null;
            }
        }

        public Inventory_Comparative_Study getComparativeStudyById(int csid)
        {
            return new NonProductionGenericRepository<Inventory_Comparative_Study>().Find(c => c.ID == csid).FirstOrDefault();
        }

        public Inventory_Comparative_Study getComparativeStudyByCSCode(string cscode)
        {
            return new NonProductionGenericRepository<Inventory_Comparative_Study>().Find(c => c.CSCode == cscode).FirstOrDefault();
        }

        public Inventory_Comparative_Study updateComparativeStudy(Inventory_Comparative_Study cs)
        {
            return new NonProductionGenericRepository<Inventory_Comparative_Study>().Update(cs, c => c.ID == cs.ID);
        }
    }
}