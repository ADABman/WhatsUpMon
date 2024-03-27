using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsUpMon.Api.Dtos.Device
{
    public class DeviceDto
    {

        public int DeviceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;


        public int DeviceTypeId { get; set; }

        // Navigation property for the one-to-many relationship with DeviceType
        // [ForeignKey("DeviceTypeId")] // Specifies the foreign key in the relationship
        // public DeviceType? DeviceType { get; set; }
    }
}