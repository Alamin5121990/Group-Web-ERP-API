using System;

namespace WebERPAPI.DTO
{
    public class Workstation
    {
        public string WorkstationName { get; set; }
        public string IPAddress { get; set; }
        public Boolean IsAvailable { get; set; }
        public DateTime CheckedOn { get; set; }
    }
}