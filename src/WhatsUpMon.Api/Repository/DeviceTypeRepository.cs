using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatsUpMon.Api.Data;
using WhatsUpMon.Api.Dtos.DeviceType;
using WhatsUpMon.Api.Interfaces;
using WhatsUpMon.Api.Models;

namespace WhatsUpMon.Api.Repository
{
    // Repository classes are used to interact with the database.
    // Use CTRL + . to generate the missing interface members while the cursor is on the interface name
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private readonly ApplicationDBContext _context;
        public DeviceTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<DeviceType> CreateAsync(DeviceType deviceTypeModel)
        {
            await _context.DeviceTypes.AddAsync(deviceTypeModel);
            await _context.SaveChangesAsync();
            return deviceTypeModel;
        }

        public async Task<DeviceType?> DeleteAsync(int id)
        {
            var deviceTypeModel = await _context.DeviceTypes.FirstOrDefaultAsync(dt => dt.DeviceTypeId == id);
            if (deviceTypeModel == null)
            {
                return null;
            }
            _context.DeviceTypes.Remove(deviceTypeModel);
            await _context.SaveChangesAsync();
            return deviceTypeModel;
        }

        public async Task<List<DeviceType>> GetAllAsync()
        {
            return await _context.DeviceTypes.ToListAsync();
        }

        public async Task<DeviceType?> GetByIdAsync(int id)
        {
            return await _context.DeviceTypes.FindAsync(id);
        }

        public async Task<DeviceType?> UpdateAsync(int id, UpdateDeviceTypeRequestDto updateDto)
        {
            var existingDeviceType = await _context.DeviceTypes.FirstOrDefaultAsync(dt => dt.DeviceTypeId == id);
            if (existingDeviceType == null)
            {
                return null;
            }
            existingDeviceType.Name = updateDto.Name;
            await _context.SaveChangesAsync();
            return existingDeviceType;

        }
    }
}