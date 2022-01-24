using System;

namespace WebERPAPI.BusinessLogic.User
{
    public class ErrorLogService
    {
        public string getErrorMessages(Exception Error)
        {
            try
            {
                string ExceptionTitle = "";
                string ExceptionDetails = "";

                if (!string.IsNullOrEmpty(Error.Message)) ExceptionTitle = Error.Message;
                ExceptionDetails = getAllErrorString(Error);

                return ExceptionTitle + ", Details:  " + ExceptionDetails;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string getAllErrorString(Exception ex)
        {
            try
            {
                string Message = "";

                // Source
                if (!string.IsNullOrEmpty(ex.Source)) Message = "Source -> " + ex.Source + "\r\n";

                // Message
                if (!string.IsNullOrEmpty(ex.Message)) Message += ex.Message + "\r\n";

                if (ex.InnerException != null)
                {
                    var iEx = ex.InnerException;
                    if (!string.IsNullOrEmpty(iEx.Message))
                    {
                        if (!string.IsNullOrEmpty(iEx.Source)) Message += "Source -> " + iEx.Source + "\r\n";
                        Message += iEx.Message + "\r\n";
                    }
                }

                return Message;
            }
            catch { return ""; }
        }
    }
}