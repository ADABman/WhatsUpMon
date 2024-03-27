using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhatsUpMon.Api.Interfaces;
using WhatsUpMon.Api.Mappers;
using WhatsUpMon.Api.Repository;


namespace WhatsUpMon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Or [Route("api/device")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepo;
        public DeviceController(IDeviceRepository deviceRepo)
        {
            _deviceRepo = deviceRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var devices = await _deviceRepo.GetAllAsync();
            var deviceDto = devices.Select(d => d.ToDeviceDto());
            return Ok(deviceDto);

        }

    }
}