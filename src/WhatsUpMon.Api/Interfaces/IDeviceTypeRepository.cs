using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsUpMon.Api.Dtos.DeviceType;
using WhatsUpMon.Api.Models;

namespace WhatsUpMon.Api.Interfaces
{
    public interface IDeviceTypeRepository
    {
        Task<List<DeviceType>> GetAllAsync();
        Task<DeviceType?> GetByIdAsync(int id); // FirstOrDefaultAsync() returns null if not found, thus the ?
        Task<DeviceType> CreateAsync(DeviceType deviceTypeModel);
        Task<DeviceType?> UpdateAsync(int id, UpdateDeviceTypeRequestDto updateDto);
        Task<DeviceType?> DeleteAsync(int id);
    }
}