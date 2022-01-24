using LPLERP.Common;
using System;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO.Employee;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.Repository
{
    public class RegisterRepo
    {
        public Exception error = new Exception();
        public string LocationID = "";
        public string Department = "";
        public string Designation = "";

        private SystemManagerEntities db = new SystemManagerEntities();
    }
}