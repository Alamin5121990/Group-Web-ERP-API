using System;

namespace WebERPAPI.DTO.User.Complain
{
    public class UserComplainsNewDto
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> UserComplainTypeID { get; set; }
        public string Details { get; set; }
        public string Recepients { get; set; }
        public string ScreenshotInBase64 { get; set; }
        public Nullable<Boolean> IsSolved { get; set; }
        public Nullable<int> CreatedByID { get; set; }
    }
}