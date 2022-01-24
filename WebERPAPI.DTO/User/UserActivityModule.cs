using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.User
{
    public static class UserActivityModule
    {
        public static string REQUISITION_IMPORT_ROLLBACK = "REQUISITION_IMPORT_ROLLBACK";
        public static string REQUISITION_LOCAL_ROLLBACK = "REQUISITION_LOCAL_ROLLBACK";

        public static string QUOTATION_IMPORT_ROLLBACK = "QUOTATION_IMPORT_ROLLBACK";
        public static string QUOTATION_LOCAL_ROLLBACK = "QUOTATION_LOCAL_ROLLBACK";

        public static string CS_IMPORT_ROLLBACK = "CS_IMPORT_ROLLBACK";
        public static string CS_LOCAL_ROLLBACK = "CS_LOCAL_ROLLBACK";

        public static string PO_ROLLBACK = "PO_ROLLBACK";
    }
}