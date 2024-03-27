using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsUpMon.Api.Dtos.Device;
using WhatsUpMon.Api.Models;

namespace WhatsUpMon.Api.Mappers
{
    public static class DeviceMapper
    {
        public static DeviceDto ToDeviceDto(this Device deviceModel)
        {
            return new DeviceDto
            {
                DeviceId = deviceModel.DeviceId,
                Name = deviceModel.Name,
                IPAddress = deviceModel.IPAddress,
                Username = deviceModel.Username,
                Password = deviceModel.Password,
                DeviceTypeId = deviceModel.DeviceTypeId
            };
        }
    }
}