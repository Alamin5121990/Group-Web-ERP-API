using System;

namespace LabaidMIS.Data.Classes.Maintenance
{
    public class UserDeviceHistory
    {
        public string GUID { get; set; }
        public string IPAddress { get; set; }
        public string DeviceDetails { get; set; }
        public string LocationDetails { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<DateTime> LastLoggedOn { get; set; }
    }
}