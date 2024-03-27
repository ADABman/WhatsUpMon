using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatsUpMon.Api.Data;
using WhatsUpMon.Api.Interfaces;
using WhatsUpMon.Api.Models;

namespace WhatsUpMon.Api.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDBContext _context;

        public DeviceRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }
    }
}