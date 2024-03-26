using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsUpMon.Api.Models;

namespace WhatsUpMon.Api.Dtos
{
    public class DeviceTypeDto
    {
        // Bring in all fields of the DeciveType model, remote annotations
        // Then we can remove fields we don't want to expose to the client.
        // So far we have not removed any fields. We may not do it here, but in the mapper class later.
        // This is a DTO object, and in Mappers/DeviceTypeMappers.cs we make a copy of this object
        // and remove fields we don't want to expose or add fields we want to expose etc.
        public int DeviceTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        // We may or may not want to expose the Devices list here. ?
        public List<Device> Devices { get; set; } = new List<Device>();
    }
}