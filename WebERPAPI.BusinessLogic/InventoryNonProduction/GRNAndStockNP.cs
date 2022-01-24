using System;
using System.Collections.Generic;
using System.Text;
using WebERPAPI.BusinessLogic.Interfaces;
using WebERPAPI.BusinessLogic.Inventory;
using WebERPAPI.BusinessLogic.Map;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.Inventory.PurchaseOrdersNP;
using WebERPAPI.DTO.InventoryNonProduction;
using WebERPAPI.Library;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class GRNAndStockNP
    {
        public Exception Error = new Exception();
        private GRNNPRepositories repo = new GRNNPRepositories();

        public Inventory_GRN saveGRN(GRNNewDTO GRNData)
        {
            try
            {
                // GRN Validation
                string reqValidation = checkGRN(GRNData);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to save GRN. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;

                Inventory_GRN GRN = new GRNNPMap().map(GRNData);
                List<GRNNewItemsDTO> grnItems = JSONSerialize.getJSON<GRNNewItemsDTO>(GRNData.Data);

                // Checking PO details
                if (grnItems == null || grnItems.Count <= 0)
                {
                    Error = new Exception("Failed to save GRN. No GRN details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                // GRN Item Validation
                string detailValidation = checkGRNDetails(grnItems, true);
                if (!string.IsNullOrEmpty(detailValidation))
                {
                    Error = new Exception("Failed to save GRN." + detailValidation);
                    return null;
                }

                // SAVE
                Inventory_GRN newGRN = repo.saveGRN(GRN, grnItems);

                // Checking the existing PO
                if (newGRN == null)
                {
                    Error = new Exception("Failed to save GRN. Please try again.");
                    return null;
                }

                // GRN DETAILS
                foreach (GRNNewItemsDTO item in grnItems)
                {
                    Inventory_GRN_Items newGD = new GRNNPMap().map(item);

                    newGD.GRNID = newGRN.ID;
                    newGD.IsActive = true;
                    newGD.CreatedByID = GRNData.CreatedByID;
                    newGD.CreatedOn = DateTime.Now;
                    newGD.POID = GRNData.POID;

                    newGD = new ProcurementGenericRepository<Inventory_GRN_Items>().Insert(newGD);
                    if (newGD.ID > 0) numberOfSuccess++;
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save GRN details. Please try again.");
                    return null;
                }

                //Send Email for new GRN

                //sendNewGRNEmail(newGRN);

                return newGRN;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        private bool sendNewGRNEmail(Inventory_GRN newGRN)
        {
            //requisition has item real spec that why pulling requisition item

            //getting po item list for getting requisition id
            List<Inventory_Purchase_Order_Detail> POItemList = new PurchaseOrderNP().getPurchaseOrderItemListByPoid(newGRN.POID);
            List<InventoryRequisitionDetails> ItemListWithSpec = new RequisitionNP().getInventoryRequisitionDetails(POItemList[0].RequisitionID);
            List<GRNDetailsNPDTO> ItemList = repo.getGRNDetails(newGRN.GRNCode, newGRN.ID);

            List<InventoryRequisitionDetails> ItemListForMail = new List<InventoryRequisitionDetails>();

            foreach (var item in ItemList)
            {
                //finding which item has grn qty and in
                if (item.Quantity > 0)
                {
                    var SelectedItem = ItemListWithSpec.Find(i => i.ItemID == item.ItemID && item.POQuantity == item.POQuantity);
                    SelectedItem.Quantity = item.Quantity;
                    ItemListForMail.Add(SelectedItem);
                    //now add detail to html template
                }
            }
            string EmailSubject = "New GRN Received ! Store : " + new InventorySettings().getInventoryStoreById(newGRN.StoreID).StoreName;

            string MailBody = GetEmailBodyForGRNEmail(newGRN, ItemListForMail, new UserRepositories().getEmailSignature(newGRN.CreatedByID));

            var sentSuccess = new UserRepositories().sendEmail(null, "shourav.it@labaidpharma.com", "shourav45@gmail.com;", EmailSubject, MailBody);

            return true;
        }

        public string GetEmailBodyForGRNEmail(Inventory_GRN GRN, List<InventoryRequisitionDetails> ItemListForMail, string SignatureString)
        {
            string EmailBody = string.Empty;

            try
            {
                EmailBody = "<!DOCTYPE html><html lang='en'>";
                EmailBody += "<head><title>New GRN Email Format</title><style>";
                EmailBody += "#materials{border-collapse: collapse;width: 100%;}";
                EmailBody += "#materials td, #materials th {border: 1px solid #1E1E1E;padding: 8px;}";
                EmailBody += "#materials tr:nth-child(even) {background-color: #f2f2f2;}";
                EmailBody += "#materials th {padding-top: 12px;padding-bottom: 12px;text-align: center;background-color: white;color: black;font-size: 14px;}";
                EmailBody += "#materials td {font-size: 14px;}</style></head>";
                EmailBody += "<body><div style='max-width: 100%; max-height: auto; border: 1px solid white;'><div style='text-align: center;'>";
                EmailBody += "<p style='font-size: 24px;margin:0px;'>Labaid Pharmaceuticals Ltd </p><small>Bay Tower, House-23, Gulshan Avenue, Gulshan-1, Dhaka-1212</small></div>";
                EmailBody += "<div style='width:98%;margin-top:25px; text-align:center;'><div style='float:left;width:300px;'><p style='font-size: 14px;'><b>GRN No. : " + GRN.GRNCode.ToString() + "</b></p></div>";
                EmailBody += "<div style='float:right;width:300px;'><p style='font-size: 14px;'>Date: " + DateTime.Now.ToString("MMMM dd, yyyy") + "</p></div>";
                EmailBody += "<div style='display: inline-block; margin:0 auto; width:300px;'><p style='font-size: 14px;'>Store : " + new InventorySettings().getInventoryStoreById(GRN.StoreID).StoreName + " <br> Challan No. : " + GRN.ChallanNumber + " <br> Challan Date : " + Convert.ToDateTime(GRN.ChallanDate).ToString("MMMM dd, yyyy") + "</p></div></div>";
                EmailBody += "<div style='width:90%; text-align: left; margin-left: 45px;'><p style='font-size: 14px;'>To,</p><p style='font-size: 14px;'>Dear Sir,</p>";
                EmailBody += "<p style='font-size: 14px; word-wrap: break-word; text-align: left;'>Please find herewith new GRN has beed received. </p></div>";
                EmailBody += "<div style='width:950px; text-align: center; margin-left: 45px;'><table id='materials'><thead><tr>";
                //item table start
                EmailBody += "<th style='max-width: 50px;'>SL.</th>";
                EmailBody += "<th style='max-width: 100px;'>Group</th>";
                EmailBody += "<th style='max-width: 100px;'>Sub Group</th>";

                EmailBody += "<th style='max-width: 500px;'>Item</th>";

                EmailBody += "<th style='max-width: 100px;'>Quantity</th>";
                EmailBody += "<th style='max-width: 100px;'>UOM</th>";

                EmailBody += "</tr></thead><tbody>";

                int serial = 1;
                foreach (var item in ItemListForMail)
                {
                    EmailBody += "<tr><td style='max-width: 50px; text-align: center'>" + serial.ToString() + "</td>";
                    serial++;
                    EmailBody += "<td style='max-width: 100px; text-align: center'>" + item.MainGroupName + "</td>";
                    EmailBody += "<td style='max-width: 100px; text-align: center'>" + item.SubGroupName + "</td>";

                    EmailBody += "<td style='max-width: 500px; word-wrap: break-word; text-align: left;'> Code: " + item.ItemCode + "<br/> <strong>" + item.ItemName + "</strong><br/><br/> <strong>Specifications :</strong>";
                    //spec table
                    EmailBody += "<table style='background-color:white;'>";

                    foreach (var spec in item.Specifications)
                    {
                        EmailBody += "<tr><td style='border:white;background-color:white;padding: 2px; ;'>" + spec.SpecificationName + " :</td><td style='border:white;background-color:white;padding: 2px; ;'>" + spec.SpecificationValue.ToString() + "</td><tr>";
                    }
                    EmailBody += "</table>";
                    EmailBody += "</td><td style='max-width: 100px; text-align: center'>" + item.Quantity + "</td><td style='max-width: 100px; text-align: center'>" + item.UOM + "</td></tr>";
                }

                EmailBody += "</tbody></table></div> <br>";

                EmailBody += SignatureString;
            }
            catch (Exception ex)
            {
                EmailBody = string.Empty;
            }

            return EmailBody;
        }

        private string checkGRN(GRNNewDTO GRNData)
        {
            try
            {
                DateTime lastReceiveDate = DateTime.Now.AddHours(-(DateTime.Now.Hour + 2));

                if (string.IsNullOrEmpty(GRNData.Data)) return "GRN details not found.";
                if (string.IsNullOrEmpty(GRNData.CreatedByID)) return "Employee code not found";
                if (GRNData.POID <= 0) return "PO ID not found";

                if (string.IsNullOrEmpty(GRNData.VATChallanNumber)) GRNData.VATChallanDate = null;

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        private string checkGRNDetails(List<GRNNewItemsDTO> GRNItems, Boolean PreventDuplicate = false)
        {
            try
            {
                foreach (GRNNewItemsDTO item in GRNItems)
                {
                    if (item.Rate <= 0) return "Invalid item rate. Rate must be larger than 0";
                    if (item.ItemID <= 0) return "Item id not found";

                    //item.
                }

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public object getGRNReport(string GRNCode, int GRNID)
        {
            try
            {
                GRNNPDTO GRN = repo.getGRNNP(GRNCode, GRNID);
                List<GRNDetailsNPDTO> GRNDetails = repo.getGRNDetails(GRNCode, GRNID);
                RequisitionNPRepositories rRepo = new RequisitionNPRepositories();

                foreach (GRNDetailsNPDTO item in GRNDetails)
                {
                    item.Specifications = new List<ItemSpecification>();
                    List<ItemSpecification> specs = rRepo.getItemSpecifications(0, item.ItemID.GetValueOrDefault());
                    if (specs != null) item.Specifications.AddRange(specs);
                }

                return new { GRN, GRNDetails };
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // QRN

        public List<GRNPendingNP> getGRNPending()
        {
            try
            {
                return repo.getGRNPending();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GRN approve
        public List<GRNPendingNP> getGRNPendingForApproveNP()
        {
            try
            {
                return repo.getGRNPendingForApproveNP();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //grn approve
        public Inventory_GRN approveGRN(string EmpID, string GRNCode)
        {
            try
            {
                return repo.approveGRN(EmpID, GRNCode);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_QRN saveQRNM(QRNNewDTO QRNData)
        {
            try
            {
                // QRN Validation
                string reqValidation = checkQRN(QRNData);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to save QRN. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;

                Inventory_QRN QRN = new GRNNPMap().map(QRNData);
                List<QRNNewItemsDTO> qrnItems = JSONSerialize.getJSON<QRNNewItemsDTO>(QRNData.Data);

                // Checking PO details
                if (qrnItems == null || qrnItems.Count <= 0)
                {
                    Error = new Exception("Failed to save QRN. No QRN details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                // GRN Item Validation
                string detailValidation = checkQRNDetails(qrnItems, true);
                if (!string.IsNullOrEmpty(detailValidation))
                {
                    Error = new Exception("Failed to save QRN." + detailValidation);
                    return null;
                }

                QRN.IsActive = true;
                QRN.CreatedOn = DateTime.Now;
                // SAVE
                Inventory_QRN newQRN = new ProcurementGenericRepository<Inventory_QRN>().Insert(QRN);

                // Checking the existing QRN
                if (newQRN == null)
                {
                    Error = new Exception("Failed to save QRN. Please try again.");
                    return null;
                }
                //getting GRN
                var GRN = repo.getGRNNP("", QRNData.GRNID);

                // QRN DETAILS
                foreach (QRNNewItemsDTO item in qrnItems)
                {
                    if (item.PassedQuantity > 0)
                    {
                        Inventory_QRN_Items newGD = new GRNNPMap().map(item);

                        newGD.QRNID = newQRN.ID;
                        newGD.IsActive = true;
                        newGD.CreatedByID = QRNData.CreatedByID;
                        newGD.CreatedOn = DateTime.Now;
                        // Saving New PO Details
                        newGD = new ProcurementGenericRepository<Inventory_QRN_Items>().Insert(newGD);
                        if (newGD.ID > 0)
                        {
                            numberOfSuccess++;
                            repo.updateInventoryStock(Convert.ToInt32(GRN.StoreID), item.ItemID, 1, newQRN.ID, 0, item.PassedQuantity, newQRN.CreatedByID, "");
                        }
                    }
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save QRN details. Please try again.");
                    return null;
                }

                // Stock IN
               // new MaintenanceRepositories().saveQRNQuantityInStock();

                return newQRN;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }
        public Inventory_QRN saveQRN(QRNNewDTO QRNData)
        {
            try
            {
                // QRN Validation
                string reqValidation = checkQRN(QRNData);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to save QRN. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;

                Inventory_QRN QRN = new GRNNPMap().map(QRNData);
                List<QRNNewItemsDTO> qrnItems = JSONSerialize.getJSON<QRNNewItemsDTO>(QRNData.Data);

                // Checking PO details
                if (qrnItems == null || qrnItems.Count <= 0)
                {
                    Error = new Exception("Failed to save QRN. No QRN details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                // GRN Item Validation
                string detailValidation = checkQRNDetails(qrnItems, true);
                if (!string.IsNullOrEmpty(detailValidation))
                {
                    Error = new Exception("Failed to save QRN." + detailValidation);
                    return null;
                }

                // SAVE
                Inventory_QRN newQRN = new ProcurementGenericRepository<Inventory_QRN>().Insert(QRN);

                // Checking the existing QRN
                if (newQRN == null)
                {
                    Error = new Exception("Failed to save QRN. Please try again.");
                    return null;
                }
                //getting GRN
                var GRN = repo.getGRNNP("", QRNData.GRNID);

                // QRN DETAILS
                foreach (QRNNewItemsDTO item in qrnItems)
                {
                    if (item.PassedQuantity > 0)
                    {
                        Inventory_QRN_Items newGD = new GRNNPMap().map(item);

                        newGD.QRNID = newQRN.ID;
                        newGD.IsActive = true;
                        newGD.CreatedByID = QRNData.CreatedByID;
                        newGD.CreatedOn = DateTime.Now;
                        // Saving New PO Details
                        newGD= new ProcurementGenericRepository<Inventory_QRN_Items>().Insert(newGD);
                        if (newGD.ID >0)
                        {
                            numberOfSuccess++;
                            repo.updateInventoryStock(Convert.ToInt32(GRN.StoreID), item.ItemID, 1, newQRN.ID, 0, item.PassedQuantity, newQRN.CreatedByID, "");
                        }
                    }
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save QRN details. Please try again.");
                    return null;
                }

                // Stock IN
                //new MaintenanceRepositories().saveQRNQuantityInStock();

                return newQRN;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        private string checkQRN(QRNNewDTO QRNData)
        {
            try
            {
                DateTime lastReceiveDate = DateTime.Now.AddHours(-(DateTime.Now.Hour + 2));

                if (QRNData.GRNID <= 0) return "GRN ID not found";
                if (string.IsNullOrEmpty(QRNData.Data)) return "GRN details not found.";
                if (string.IsNullOrEmpty(QRNData.CreatedByID)) return "Employee code not found";

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        private string checkQRNDetails(List<QRNNewItemsDTO> QRNItems, Boolean PreventDuplicate = false)
        {
            try
            {
                foreach (QRNNewItemsDTO item in QRNItems)
                {
                    if (item.ItemID <= 0) return "Item id not found";
                }

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public Inventory_UserStores saveUserStore(UserStoreNewDTO UserStore)
        {
            try
            {
                Inventory_UserStores newStore = new GRNNPMap().map(UserStore);

                Inventory_UserStores store = repo.getUserStore(UserStore.EmployeeCode, UserStore.StoreID);
                if (store == null) return repo.saveUserStore(newStore);
                else
                {
                    store.UpdatedByID = UserStore.CreatedByID;
                    store.IsActive = UserStore.IsActive;
                    store.IsIncharge = UserStore.IsIncharge;
                    return repo.updateUserStore(store.ID, store);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<UserStoresDTO> getUserStores(string EmployeeCode, int ShowAll)
        {
            try
            {
                return repo.getUserStores(EmployeeCode, ShowAll);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<GRNStatusReportNPDTO> getGRNStatusReportNP(string SupplierCode, string DateFrom, string DateTo)
        {
            try
            {
                return repo.getGRNStatusReportNP(SupplierCode, DateFrom, DateTo);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<PurchaseOrderGRNsNPDTO> getPurchaseOrderGRNList(string POCode, int POID)
        {
            try
            {
                return repo.getPurchaseOrderGRNList(POCode, POID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public Inventory_GRN cancelGRN(string employeeid, string grncode, string remark)
        {
            try
            {
                if (grncode == "" || grncode == string.Empty || remark == "" || remark == string.Empty || employeeid == "" || employeeid == string.Empty)
                {
                    throw new Exception("Field Missing.");
                }

                //Logic for cancelling all dependents

                Inventory_GRN grn = repo.getGRNByCode(grncode);
                grn.IsActive = false;
                grn.Remarks = remark;
                grn.UpdatedOn = DateTime.Now;
                grn.UpdatedByID = employeeid;

                return repo.updateGRN(grn);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<PurchaseOrderNPDto> getPurchaseOrderForGRN(string EmployeeID, string SearchText)
        {
            try
            {
                return repo.getPurchaseOrderForGRN(EmployeeID, SearchText);
            }
            catch (Exception ex) { Error = ex; return null; }
        }
    }
}