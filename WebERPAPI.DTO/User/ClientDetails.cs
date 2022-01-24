namespace WebERPAPI.DTO.User
{
    public class ClientDetails
    {
        public int UserID { get; set; }
        public string IPAddress { get; set; }
        public string DeviceInfo { get; set; }
        public string LocationInfo { get; set; }
        public string GUID { get; set; }
    }
}