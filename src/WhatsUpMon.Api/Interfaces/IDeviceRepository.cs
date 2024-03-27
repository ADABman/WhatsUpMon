using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsUpMon.Api.Models;

namespace WhatsUpMon.Api.Interfaces
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetAllAsync();
    }
}