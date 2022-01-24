using System;

namespace WebERPAPI.Data
{
    public class ErrorDetails
    {
        public string ExceptionMessage { get; set; }
        public string ExceptionDetails { get; set; }
    }

    public static class ErrorManagement
    {
        public static ErrorDetails setError(Exception ex)
        {
            try
            {
                ErrorDetails ed = new ErrorDetails();
                ed.ExceptionMessage = ex.Message;
                if (ex.InnerException != null) ed.ExceptionDetails = ex.InnerException.Message.ToString();

                return ed;
            }
            catch { return null; }
        }
    }
}