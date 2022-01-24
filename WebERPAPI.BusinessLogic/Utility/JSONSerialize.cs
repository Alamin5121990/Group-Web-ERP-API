using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace LabaidMIS.BusinessLogic.Utility
{
    public static class JSONSerialize
    {
        public static List<T> getJSON<T>(string JSONString)
        {
            try
            {
                string jsonString = Library.JSONData.DecodeBase64(JSONString);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<T> logs = ser.Deserialize<List<T>>(jsonString);

                return ser.Deserialize<List<T>>(jsonString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}