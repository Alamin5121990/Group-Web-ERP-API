using System;
using System.Collections.Generic;
using System.Linq;
using WebERPAPI.BusinessLogic.Interfaces;
using WebERPAPI.BusinessLogic.Inventory;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.Inventory.Procurement.Quotation;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.Library;
using WebERPAPI.Data.Repository;
using WebERPAPI.Data.Repository.Inventory;
using WebERPAPI.BusinessLogic.Utilities;
using System.Net.Mail;
using System.Web;
using WebERPAPI.DTO.InventoryNonProduction;
using System.IO;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class QuotationNP //: IQuotationNP
    {
        public Exception Error = new Exception();
        private QuotationNPRepositories repo = new QuotationNPRepositories();
        private RequisitionNP reqService = new RequisitionNP();
        private InventorySettings invService = new InventorySettings();
        private RequisitionNPRepositories invRepo = new RequisitionNPRepositories();

        private string EmailSubject = "";

        public List<RequisitionNPPending> getRequisitionNPPending(int empid)
        {
            try
            {
                List<RequisitionNPPending> requisitions = repo.getRequisitionNPPending(empid);

                //foreach (var req in requisitions)
                //{
                //    req.ItemList = reqService.getInventoryRequisitionDetails(Convert.ToInt32(req.RequisitionID));
                //}

                return requisitions;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<RequisitionSuppliersNP> getRequisitionSuppliersNP(int RequisitionID)
        {
            try
            {
                return repo.getRequisitionSuppliersNP(RequisitionID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<InventoryTypes> getUserInventoryTypeList(string employeeid)
        {
            try
            {
                return repo.getUserInventoryTypeList(employeeid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<UserMainGroup> getUserMainGroupList(string EmployeeID, int InventoryTypeID)
        {
            try
            {
                return repo.getUserMainGroupList(EmployeeID, InventoryTypeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public object getQuotationNew(int RequisitionID)
        {
            try
            {
                List<RequisitionSuppliersNP> Suppliers = repo.getRequisitionSuppliersNP(RequisitionID);
                List<InventoryRequisitionDetails> ItemDetails = reqService.getInventoryRequisitionDetails(RequisitionID);

                return new { ItemDetails, Suppliers };
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        // QUOTATION INVITATION

        public Inventory_Quotation_Invitations inviteQuotation(CommonDataEntryClass Quotation, string EmailTemplatePath)
        {
            try
            {
                // Quotation Validation
                string reqValidation = checkQuotation(Quotation);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to invite quotation. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;
                List<QuotationInvitationSendDetails> quotationItems = JSONSerialize.getJSON<QuotationInvitationSendDetails>(Quotation.Data);

                // Checking quotation details
                if (quotationItems == null || quotationItems.Count <= 0)
                {
                    Error = new Exception("Failed to invite quotation. No quotation details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                // Quotation Item Validation
                string detailValidation = checkQuotationItemDetails(quotationItems);
                if (!string.IsNullOrEmpty(detailValidation))
                {
                    Error = new Exception("Failed to invite quotation. " + detailValidation);
                    return null;
                }

                // SAVE
                Inventory_Quotation_Invitations newQuotation = repo.saveQuotation(Quotation);

                // Checking the existing Quotation
                if (newQuotation == null)
                {
                    Error = new Exception("Failed to invite quotation. Please try again.");
                    return null;
                }

                // Save Quotation Details
                foreach (QuotationInvitationSendDetails item in quotationItems)
                {
                    if (repo.saveQuotationInvitationDetails(newQuotation.ID, item)) numberOfSuccess++;
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save quotation details. Please try again.");
                    return null;
                }

                // SEND EMAIL

                SendQuoatationInvitationEmail(newQuotation, quotationItems, EmailTemplatePath);

                return newQuotation;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Quotation_Invitations inviteQuotationWithAttachment(CommonDataEntryClass Quotation, string EmailTemplatePath, List<string> AttachmentFileNames)
        {
            try
            {
                // Quotation Validation
                string reqValidation = checkQuotation(Quotation);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to invite quotation. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;
                List<QuotationInvitationSendDetails> quotationItems = JSONSerialize.getJSON<QuotationInvitationSendDetails>(Quotation.Data);

                // Checking quotation details
                if (quotationItems == null || quotationItems.Count <= 0)
                {
                    Error = new Exception("Failed to invite quotation. No quotation details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                // Quotation Item Validation
                string detailValidation = checkQuotationItemDetails(quotationItems);
                if (!string.IsNullOrEmpty(detailValidation))
                {
                    Error = new Exception("Failed to invite quotation. " + detailValidation);
                    return null;
                }

                // SAVE
                Inventory_Quotation_Invitations newQuotation = repo.saveQuotation(Quotation);

                // Checking the existing Quotation
                if (newQuotation == null)
                {
                    Error = new Exception("Failed to invite quotation. Please try again.");
                    return null;
                }

                // Save Quotation Details
                foreach (QuotationInvitationSendDetails item in quotationItems)
                {
                    if (repo.saveQuotationInvitationDetails(newQuotation.ID, item)) numberOfSuccess++;
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save quotation details. Please try again.");
                    return null;
                }

                // SEND EMAIL

                SendQuoatationInvitationEmailWithAttachment(newQuotation, quotationItems, EmailTemplatePath, AttachmentFileNames);

                return newQuotation;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        private Boolean SendQuoatationInvitationEmail(Inventory_Quotation_Invitations Quotation, List<QuotationInvitationSendDetails> Materials, string EmailTemplatePath)
        {
            try
            {
                UserRepositories uRepo = new UserRepositories();

                Boolean isEmailSent = false;

                List<string> suppliers = Materials.GroupBy(s => s.SupplierCode).Select(s => s.FirstOrDefault().SupplierCode).ToList();

                foreach (string SupplierCode in suppliers)
                {
                    // READ EMAIL TEMPLATE CONTENT
                    string emailContent = getEmailFormat(SupplierCode, Quotation, Materials, EmailTemplatePath);

                    Supplier supplier = new SupplierRepositories().getSupplierDetails(SupplierCode);
                    if (supplier != null)
                    {
                        //var sentSuccess = uRepo.sendEmailWithAttachment(Quotation.CreatedByID, supplier.Email, "mahbub.sharawar@labaidpharma.com;softadmin@labaidpharma.com;", EmailSubject, emailContent, attachments);
                        string ccMails = "mahbub.sharawar@labaidpharma.com;softadmin@labaidpharma.com;";
                        if (Quotation.CreatedByID == "LPL00100") ccMails = "mehedhi.comm@labaidpharma.com;mahbub.sharawar@labaidpharma.com;softadmin@labaidpharma.com;";

                        //var sentSuccess = uRepo.sendEmail(Quotation.CreatedByID, supplier.Email, ccMails, EmailSubject, emailContent);
                        //if (sentSuccess) isEmailSent = true;
                        isEmailSent = true;
                    }
                }

                if (isEmailSent)
                {
                    Inventory_Quotation_Invitations Quot = repo.getInventoryQuotation(Quotation.ID);
                    Quot.IsEmailSent = true;
                    repo.updateInventoryQuotation(Quotation.ID, Quot);
                }

                return true;
            }
            catch { return false; }
        }

        private Boolean SendQuoatationInvitationEmailWithAttachment(Inventory_Quotation_Invitations Quotation, List<QuotationInvitationSendDetails> Materials, string EmailTemplatePath, List<string> AttachmentFileNames)
        {
            try
            {
                UserRepositories uRepo = new UserRepositories();

                Boolean isEmailSent = false;

                List<string> suppliers = Materials.GroupBy(s => s.SupplierCode).Select(s => s.FirstOrDefault().SupplierCode).ToList();

                foreach (string SupplierCode in suppliers)
                {
                    // READ EMAIL TEMPLATE CONTENT
                    string emailContent = getEmailFormat(SupplierCode, Quotation, Materials, EmailTemplatePath);

                    Supplier supplier = new SupplierRepositories().getSupplierDetails(SupplierCode);
                    if (supplier != null)
                    {
                        var sentSuccess = uRepo.sendEmailWithAttachment(Quotation.CreatedByID, supplier.Email, "mahbub.sharawar@labaidpharma.com;softadmin@labaidpharma.com;", EmailSubject, emailContent, AttachmentFileNames);
                        //var sentSuccess = uRepo.sendEmailWithAttachment(Quotation.CreatedByID, "shourav45@gmail.com;", "shourav.it@labaidpharma.com;", EmailSubject, emailContent, AttachmentFileNames);

                        //System.Threading.Thread.Sleep(1000);

                        //var sentSuccess = uRepo.sendEmail(Quotation.CreatedByID, supplier.Email, "mahbub.sharawar@labaidpharma.com;softadmin@labaidpharma.com;", EmailSubject, emailContent);
                        if (sentSuccess) isEmailSent = true;
                    }
                }

                if (isEmailSent)
                {
                    Inventory_Quotation_Invitations Quot = repo.getInventoryQuotation(Quotation.ID);
                    Quot.IsEmailSent = true;
                    repo.updateInventoryQuotation(Quotation.ID, Quot);
                }

                //remove attachment files from directory
                try
                {
                    Directory.GetFiles(HttpContext.Current.Server.MapPath("~/EmailAttachmentFiles/")).ToList().ForEach(File.Delete);
                }
                catch (Exception ex) { }

                return true;
            }
            catch { return false; }
        }

        public string getEmailFormat(string SupplierCode, Inventory_Quotation_Invitations Quotation, List<QuotationInvitationSendDetails> materials, string EmailTemplatePath)
        {
            try
            {
                UserRepositories repo = new UserRepositories();
                string emailContent = "";
                DateTime lastReceiveDate = DateTime.Now;
                DateTime deliveryDate = DateTime.Now;

                Scripting.readFile(ref emailContent, EmailTemplatePath);

                string productDescription = "";
                int index = 1;

                string remarks = "", subject = "Quotation Invitation : ", materialids = "";
                string requisitionCode = "";

                List<QuotationInvitationSendDetails> Filteredmaterials = materials.Where(m => m.SupplierCode == SupplierCode).ToList();

                //now getting items from requisition item table for distinguising id
                List<Inventory_Requisition_Items> requisition_ItemList = new List<Inventory_Requisition_Items>();
                bool hasInRequisitionItemList = false;

                foreach (var item in Filteredmaterials)
                {
                    List<Inventory_Requisition_Items> ReqItems = reqService.getRequisitionItemList(item.RequisitionID, item.ItemID);

                    if (requisition_ItemList.Count == 0)
                    {
                        foreach (var reItem in ReqItems)
                        {
                            requisition_ItemList.Add(reItem);
                        }
                    }

                    foreach (var reItem in ReqItems)
                    {
                        foreach (var reqItem in requisition_ItemList)
                        {
                            if (reqItem.ID == reItem.ID) hasInRequisitionItemList = true;
                        }

                        if (hasInRequisitionItemList == false) requisition_ItemList.Add(reItem);
                        hasInRequisitionItemList = false;
                    }
                }

                foreach (Inventory_Requisition_Items material in requisition_ItemList)
                {
                    if (isSupplierHasThisItem(SupplierCode, Convert.ToInt32(material.ItemID)))
                    {
                        //if (materialids.IndexOf("<" + material.ItemID.ToString() + ">") > -1) continue;

                        Inventory_Requisitions requisition = reqService.getRequisition(Convert.ToInt32(material.RequisitionID));
                        Inventory_Requisition_Items requisitionItem = reqService.getRequisitionItems(Convert.ToInt32(material.RequisitionID), Convert.ToInt32(material.ItemID));

                        if (requisition != null) requisitionCode = requisition.RequisitionCode;
                        if (requisitionItem != null) deliveryDate = requisitionItem.DeliveryDate.GetValueOrDefault();

                        if (deliveryDate < Quotation.LastReceiveDate) deliveryDate = Quotation.LastReceiveDate.GetValueOrDefault();

                        //Material mat = mRepo.getMaterialDetails(material.MaterialCode);
                        //getting requisition item list

                        //List<ItemSpecification> specifications = invRepo.getItemSpecificationInCommas(requisition.ID, Convert.ToInt32(material.ItemID));

                        List<ItemSpecification> specifications = invRepo.getRequisitionItemSpecificationList(material.ID, requisition.ID, Convert.ToInt32(material.ItemID));
                        InventoryItems item = invService.getInventoryItem(Convert.ToInt32(material.ItemID));

                        string SpecificationTableHTML = new ListToHtml().getQuotationItemSpecificationHTML(specifications);

                        productDescription += "<tr>";

                        productDescription += "<td style='max-width: 50px; text-align: center'>" + index + "</td>";
                        productDescription += "<td style='max-width: 100px; text-align: center'>" + requisitionCode + "</td>";

                        productDescription += "<td style='max-width: 500px; word-wrap: break-word; text-align: left;'>Code: " + item.ItemCode + "<br/><strong>" + item.ItemNameWithSpec + "</strong>";
                        productDescription += "<br/><br/> <strong>Specifications :</strong> " + SpecificationTableHTML;
                        productDescription += "</td>";

                        if (subject.Length < 150) subject += item.ItemName + ", ";

                        productDescription += "<td style='max-width: 80px; text-align: center'>" + item.VersionNo + "</td>";

                        productDescription += "<td style='max-width: 100px; text-align: center'>" + Convert.ToDecimal(material.Quantity).ToString("F2") + "</td>";
                        productDescription += "<td style='max-width: 50px; text-align: center'>" + item.UOM + "</td>";
                        productDescription += "<td style='max-width: 100px; text-align: center'>" + deliveryDate.ToString("dd MMM yyyy") + "</td>";
                        productDescription += "<td style='max-width: 100px; text-align: center'>" + Quotation.LastReceiveDate.GetValueOrDefault().ToString("dd MMM yyyy") + "</td>";

                        productDescription += "</tr>";

                        materialids += "<" + material.ItemID.ToString() + ">";

                        index++;
                    }
                }

                EmailSubject = Library.TextConvert.ShortSubject(Scripting.removeLastComma(subject));

               // emailContent = emailContent.Replace("[REMARKS]", "Remarks: <br/>" + remarks + "<br/>" + Quotation.Remarks);

                //emailContent = emailContent.Replace("[TOKEN_LINK]", "https://www.lplmis.com/#/vendor/quotation/entry?Token=" + Token);
                emailContent = emailContent.Replace("[TOKEN_LINK]", "");

                emailContent = emailContent.Replace("[PRODUCT_DESCRIPTION]", productDescription);
                emailContent = emailContent.Replace("[QUOTATION_DATE]", DateTime.Now.ToString("dd MMM yyyy"));

                emailContent = emailContent.Replace("[QUOTATION_RECEIVE_DATE]", Quotation.LastReceiveDate.GetValueOrDefault().ToString("dd MMM yyyy"));
                emailContent = emailContent.Replace("[QUOTATION_NO]", Quotation.QuotationCode.ToString());

                emailContent = emailContent.Replace("[SIGNATURE]", repo.getEmailSignature(Quotation.CreatedByID));

                //Scripting.writeFile(ref emailContent, Path.Combine(TemplatePath, "quotationinvitation.html"));
                return emailContent;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public bool isSupplierHasThisItem(string SupplierCode, int itemID)
        {
            Inventory_Items itemDetails = invRepo.getInventoryItem(itemID);

            List<Inventory_SubGroup_Suppliers> itemSupplierList = new InventorySettings().getInventoryMainGroupSupplierListByMaingroupId(Convert.ToInt32(itemDetails.SubGroupId));

            foreach (var item in itemSupplierList)
            {
                if (item.SupplierCode == SupplierCode)
                {
                    return true;
                }
            }

            return false;
        }

        private string checkQuotation(CommonDataEntryClass Quotation)
        {
            try
            {
                DateTime lastReceiveDate = DateTime.Now.AddHours(-(DateTime.Now.Hour + 2));

                if (Quotation == null) return "Quotation object is null in checkQuotation. Please try again";
                if (string.IsNullOrEmpty(Quotation.Data)) return "Quotation details not found.";
                if (Quotation.Date == null || Quotation.Date < lastReceiveDate) return "Invalid quotation last receive date.";
                if (string.IsNullOrEmpty(Quotation.EmployeeCode)) return "Employee code not found";

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        private string checkQuotationItemDetails(List<QuotationInvitationSendDetails> QuotationItems)
        {
            try
            {
                foreach (QuotationInvitationSendDetails item in QuotationItems)
                {
                    if (item.RequisitionID <= 0) return "Requisition id not found";
                    if (item.ItemID <= 0) return "Item id not found";
                    if (string.IsNullOrEmpty(item.SupplierCode)) return "Supplier Code not found";

                    Inventory_Items invItem = invRepo.getInventoryItem(item.ItemID);
                    if (item.Quantity < invItem.MOQ) return "Quotation item quantity must be higher or equal to Minimum Order Quantity(MOQ)";

                    Inventory_Quotation_Invitations quotation = getActiveExistingQuotation(item.RequisitionID);
                    if (quotation != null)
                    {
                        return "Quotation is already invited. ( QuotationCode = " + quotation.QuotationCode + ", Created on: " + quotation.CreatedOn.GetValueOrDefault().ToString("dd MMM yyyy") + ")";
                    }
                }

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        // CANCEL QUOTATION
        public Inventory_Quotation_Invitations cancelQuotation(CommonDataEntryClass Quotation)
        {
            try
            {
                if (string.IsNullOrEmpty(Quotation.Remarks))
                {
                    Error = new Exception("Failed to cancel quotation. Please enter reason to cancel.");
                    return null;
                }

                if (string.IsNullOrEmpty(Quotation.EmployeeCode))
                {
                    Error = new Exception("Failed to cancel quotation. Employee Code not found.");
                    return null;
                }

                return repo.cancelQuotation(Quotation);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Quotation_Invitations getActiveExistingQuotation(int RequisitionID)
        {
            try
            {
                return repo.getActiveExistingQuotation(RequisitionID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<QuotationsNonProduction> getQuotationsNonProduction(int empid, int ActionGroupID)
        {
            try
            {
                var data = repo.getQuotationsNonProduction(empid, ActionGroupID);

                return data;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<QuotationsNonProduction> getQuotationsCancelList(int empid)
        {
            try
            {
                return repo.getQuotationsCancelList(empid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public object getQuotationsDetailsNP(int QuotationID, string QuotationCode)
        {
            try
            {
                List<QuotationDetailsNP> Report = new List<QuotationDetailsNP>();

                List<QuotationItemsNP> Items = repo.getQuotationItemsNP(QuotationID, QuotationCode);
                //here getting multiple supplier for same item
                List<QuotationSuppliersNP> Suppliers = repo.getQuotationSuppliersNP(QuotationID, QuotationCode);
                //List<Inventory_Quotation_Invitation_Details> QuotationDetails = repo.getQuotationDetails(QuotationID);
                List<Inventory_Quotation_Received_Details> QuotationReceiveDetails = repo.getQuotationReceiveDetails(QuotationID);

                QuotationReceiveDetails = QuotationReceiveDetails.OrderByDescending(a => a.ItemID).ToList();

                foreach (QuotationItemsNP item in Items)
                {
                    QuotationDetailsNP rpt = new QuotationDetailsNP();

                    rpt.ItemID = item.ItemID;

                    rpt.ItemCode = item.ItemCode;
                    rpt.ItemName = item.ItemName;
                    rpt.ItemNameWithSpec = item.ItemName;
                    rpt.Quantity = item.Quantity;
                    rpt.MOQ = item.MOQ;
                    rpt.UOM = item.UOM;
                    rpt.MainGroupName = item.MainGroupName;
                    rpt.DeliveryDate = item.DeliveryDate;
                    rpt.SubGroupId = item.SubGroupId;
                    rpt.SubGroupName = item.SubGroupName;
                    rpt.RequisitionID = item.RequisitionID;
                    rpt.RequisitionCode = item.RequisitionCode;

                    // SPECIFICATION

                    rpt.Specifications = new List<ItemSpecification>();

                    List<ItemSpecification> Specs = invRepo.getRequisitionItemSpecificationList(Convert.ToInt32(item.RequisitionItemID), Convert.ToInt32(item.RequisitionID), item.ItemID.GetValueOrDefault());
                    //invRepo.getItemSpecifications(Convert.ToInt32(item.RequisitionID), item.ItemID.GetValueOrDefault());

                    if (Specs != null)
                    {
                        rpt.Specifications.AddRange(Specs);
                        rpt.ItemNameWithSpec = invService.getItemNameWithSpec(item.ItemName, Specs);
                    }

                    // Adding item suppliers
                    AddSuppliersToReport(rpt, item, Suppliers, QuotationReceiveDetails, null);

                    Report.Add(rpt);
                };

                foreach (QuotationSuppliersNP supplier in Report[0].Suppliers)
                {
                    if (supplier.AllItemTotalPrice == null) supplier.AllItemTotalPrice = 0;

                    foreach (QuotationDetailsNP item in Report)
                    {
                        QuotationSuppliersNP qt = item.Suppliers.FirstOrDefault(s => s.SupplierCode == supplier.SupplierCode);
                        if (qt != null)
                        {
                            supplier.AllItemTotalPrice +=(qt.Quantity.GetValueOrDefault() * qt.Rate.GetValueOrDefault());
                        }
                    }
                }

                return Report;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Boolean AddSuppliersToReport(QuotationDetailsNP rpt, QuotationItemsNP Item, List<QuotationSuppliersNP> Suppliers, List<Inventory_Quotation_Received_Details> ReceiveDetails, List<Inventory_Comparative_Study_Details> CSDetails)
        {
            rpt.Suppliers = new List<QuotationSuppliersNP>();
            if (Suppliers == null || Suppliers.Count == 0) return false;

            // Adding Item Suppliers
            List<QuotationSuppliersNP> itemSuppliers = Suppliers.Where(s => s.ItemID == Item.ItemID && s.InvitedQuantity == Item.Quantity && s.RequisitionItemID == Item.RequisitionItemID).ToList();
            if (itemSuppliers == null || itemSuppliers.Count == 0) return false;
            rpt.Suppliers.AddRange(itemSuppliers);

            //
            if (ReceiveDetails == null || ReceiveDetails.Count == 0)
            {
                foreach (QuotationSuppliersNP supplier in rpt.Suppliers) { supplier.Quantity = supplier.InvitedQuantity; }
                return true;
            }

            // LOWEST BIDDER
            Inventory_Quotation_Received_Details lowestBidder = ReceiveDetails.Where(
                    q => q.ItemID == Item.ItemID && q.Quantity == Item.Quantity && q.Rate > 0).OrderBy(q => q.Rate).FirstOrDefault();

            // Setting Receive Details
            foreach (QuotationSuppliersNP supplier in rpt.Suppliers)
            {
                supplier.IsSelected = false;

                // Receive details
                Inventory_Quotation_Received_Details rcDetails = ReceiveDetails.FirstOrDefault(
                                        q => q.QuotationID == supplier.QuotationID
                                        && q.RequisitionID == supplier.RequisitionID
                                        && q.Quantity == Item.Quantity
                                        && q.ItemID == Item.ItemID
                                        && Item.RequisitionItemID == supplier.RequisitionItemID
                                        && q.SupplierCode == supplier.SupplierCode
                                        && q.SupplierCode == supplier.SupplierCode);
                if (rcDetails != null)
                {
                    supplier.Quantity = rcDetails.Quantity;
                    supplier.Rate = rcDetails.Rate;
                    supplier.BillPaymentTypeID = rcDetails.BillPaymentTypeID;
                    supplier.BillCurrencyTypeID = rcDetails.CurrencyId;
                    supplier.Currency = rcDetails.Currency;

                    supplier.CreditDays = rcDetails.CreditDays;
                    supplier.VendorRemarks = rcDetails.VendorRemarks;
                    supplier.SupplierSpecification = rcDetails.SupplierSpecification;

                    supplier.RemarksForSupplierSpec = rcDetails.RemarksForSupplierSpec;

                    supplier.IsSpecificationMatched = rcDetails.IsSpecificationMatched;
                }
                else supplier.Quantity = supplier.InvitedQuantity;

                // LOWEST BIDDER
                if (lowestBidder != null && lowestBidder.SupplierCode == supplier.SupplierCode) supplier.IsLowestBidder = true;

                // Comparative study
                if (CSDetails != null)
                {
                    Inventory_Comparative_Study_Details csd = CSDetails.FirstOrDefault(
                        c => c.ItemID == Item.ItemID
                        && c.RequisitionID == Item.RequisitionID
                        && c.SupplierCode == supplier.SupplierCode
                        && c.Quantity == Item.Quantity
                        && c.IsActive == true);

                    if (csd != null)
                    {
                        supplier.Quantity = csd.Quantity;
                        supplier.Rate = csd.Rate;
                        supplier.IsSelected = true;
                    }
                }
            }
            return true;
        }

        public List<Bill_PaymentType> getBillPaymentTypes()
        {
            try
            {
                return repo.getBillPaymentTypes();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Quotation_Received receiveQuotation(CommonDataEntryClass Quotation)
        {
            try
            {
                // Quotation Validation
                string reqValidation = checkQuotationReceive(Quotation);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to invite quotation. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;
                int QuotationID = 0;

                List<Inventory_Quotation_Received_Details> quotationItems = JSONSerialize.getJSON<Inventory_Quotation_Received_Details>(Quotation.Data);

                List<QuotationSuppliersNP> OtherCostSupplier = JSONSerialize.getJSON<QuotationSuppliersNP>(Quotation.Code);

                // Checking quotation details
                if (quotationItems == null || quotationItems.Count <= 0)
                {
                    Error = new Exception("Failed to invite quotation. No quotation details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                // Quotation Item Validation
                string detailValidation = checkQuotationReceiveItemDetails(quotationItems, OtherCostSupplier);
                if (!string.IsNullOrEmpty(detailValidation))
                {
                    Error = new Exception("Failed to invite quotation. " + detailValidation);
                    return null;
                }

                QuotationID = quotationItems[0].QuotationID;

                // SAVE

                Inventory_Quotation_Received receivedQuotation = repo.getExistingQuotationReceive(QuotationID);

                if (receivedQuotation == null) receivedQuotation = repo.receiveQuotation(QuotationID, Quotation);
                else repo.updateQuotationReceive(receivedQuotation.ID, QuotationID, Quotation);

                // Checking the existing Quotation
                if (receivedQuotation == null)
                {
                    Error = new Exception("Failed to receive quotation. Please try again.");
                    return null;
                }

                // Save Quotation Details

                repo.cancelAllReceive(QuotationID, Quotation.EmployeeCode);

                foreach (Inventory_Quotation_Received_Details supplier in quotationItems)
                {
                    if (repo.saveQuotationReceiveDetails(receivedQuotation.ID, supplier, Quotation.EmployeeCode)) numberOfSuccess++;
                }

                //save other cost data

                foreach (var item in OtherCostSupplier)
                {
                    Inventory_Quotation_Received_OtherCost iqro = new Inventory_Quotation_Received_OtherCost();
                    iqro.CarryingCost = item.CarryingCost;
                    iqro.CreatedOn = DateTime.Now;
                    iqro.IsActive = true;
                    iqro.LabourCost = item.LabourCost;
                    iqro.QuotationID = QuotationID;
                    iqro.SupplierCode = item.SupplierCode;
                    iqro.OtherCostName = item.OtherCostName;
                    iqro.OtherCost = item.OtherCost;
                    iqro.Discount = item.Discount;
                    repo.saveOtherCost(iqro);
                }
                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save quotation details. Please try again.");
                    return null;
                }

                return receivedQuotation;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        private string checkQuotationReceive(CommonDataEntryClass Quotation)
        {
            try
            {
                DateTime lastReceiveDate = DateTime.Now.AddHours(-(DateTime.Now.Hour + 2));

                if (string.IsNullOrEmpty(Quotation.Data)) return "Quotation details not found.";
                if (string.IsNullOrEmpty(Quotation.EmployeeCode)) return "Employee code not found";

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public Inventory_Quotation_Invitations cancelQuotation(int quotationid, string remark, string employeeid)
        {
            try
            {
                Inventory_Quotation_Invitations iqi = repo.getInventoryQuotation(quotationid);

                iqi.CanceledBy = employeeid;
                iqi.CanceledOn = DateTime.Now;
                iqi.IsCanceled = true;
                iqi.ReasonToCanceled = remark;

                return repo.updateInventoryQuotation(iqi.ID, iqi);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        private string checkQuotationReceiveItemDetails(List<Inventory_Quotation_Received_Details> Suppliers, List<QuotationSuppliersNP> OtherCostSupplier)
        {
            try
            {
                foreach (Inventory_Quotation_Received_Details supplier in Suppliers)
                {
                    if (supplier.RequisitionID <= 0) return "Requisition id not found";
                    if (supplier.QuotationID <= 0) return "Invitation ID not found";
                    if (supplier.ItemID <= 0) return "Item id not found";
                    if (string.IsNullOrEmpty(supplier.SupplierCode)) return "Supplier Code not found";

                    Inventory_Items invItem = invRepo.getInventoryItem(supplier.ItemID);
                    if (supplier.Quantity < invItem.MOQ) return "Quotation item quantity must be higher or equal to Minimum Order Quantity(MOQ)";

                    //Inventory_Quotation_Invitations quotation = getActiveExistingQuotation(supplier.RequisitionID);
                    //if (quotation != null)
                    //{
                    //    return "Quotation is already invited. ( QuotationCode = " + quotation.QuotationCode + ", Created on: " + quotation.CreatedOn.GetValueOrDefault().ToString("dd MMM yyyy") + ")";
                    //}
                }

                foreach (var item in OtherCostSupplier)
                {
                    if (item.OtherCost > 0 && item.OtherCostName == null)
                    {
                        return "Please enter the other cost name.";
                    }
                    else if (item.OtherCostName == null && item.OtherCost == 0)
                    {
                        continue;
                    }
                    else if (item.OtherCostName.Length > 2 && item.OtherCost == 0)
                    {
                        return "Please enter the other cost amount.";
                    }
                }

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }
    }
}