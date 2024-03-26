using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsUpMon.Api.Dtos.DeviceType
{
    public class UpdateDeviceTypeRequestDto
    {
        // This Dto is used when posting an update of DeviceType to the server.
        // We don't need the DeviceTypeId here, because it is passed in the URL.
        // We also don't need the Devices list here, we dont want clients to update the Devices list.??
        // Only the Name is needed.
        public string Name { get; set; } = string.Empty;
    }
}