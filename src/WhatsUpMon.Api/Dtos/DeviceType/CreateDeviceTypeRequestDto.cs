using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsUpMon.Api.Models;

namespace WhatsUpMon.Api.Dtos.DeviceType
{
    public class CreateDeviceTypeRequestDto
    {
        // This Dto is used when posting a new DeviceType to the server.
        // We don't need the DeviceTypeId here, because it is generated by the server.
        // We also don't need the Device list here, we dont want clients to create a Device list. ??
        // Only the Name is needed.
        public string Name { get; set; } = string.Empty;
    }
}