using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsUpMon.Api.Dtos;
using WhatsUpMon.Api.Dtos.DeviceType;
using WhatsUpMon.Api.Models;

namespace WhatsUpMon.Api.Mappers
{
    public static class DeviceTypeMappers
    {
        // This Dto is used when getting a DeviceType from the server.
        public static DeviceTypeDto ToDeviceTypeDto(this DeviceType devicetypeModel)
        {
            return new DeviceTypeDto
            {
                // We have made a copy of the DeviceType dto object in Dtos/DeviceTypeDto.cs
                // We can now add/remove/modify fields as needed to be returned to the client
                DeviceTypeId = devicetypeModel.DeviceTypeId,
                Name = devicetypeModel.Name,
                // Devices = devicetypeModel.Devices
            };
        }
        // This Dto is used when posting a new DeviceType to the server.
        public static DeviceType toDeviceTypeFromCreateDto(this CreateDeviceTypeRequestDto devicetypeDto)
        {
            return new DeviceType
            {
                Name = devicetypeDto.Name,
            };

        }
    }
}