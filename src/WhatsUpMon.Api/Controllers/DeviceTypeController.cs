using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhatsUpMon.Api.Data;
using WhatsUpMon.Api.Dtos.DeviceType;
using WhatsUpMon.Api.Interfaces;
using WhatsUpMon.Api.Mappers;

namespace WhatsUpMon.Api.Controllers
{
    [Route("api/[controller]")] // Or could use [Route("api/DeviceType")]
    [ApiController]
    public class DeviceTypeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IDeviceTypeRepository _deviceTypeRepo;

        public DeviceTypeController(ApplicationDBContext context, IDeviceTypeRepository deviceTypeRepo)
        {
            _deviceTypeRepo = deviceTypeRepo;
            _context = context;
        }

        // GET: api/DeviceType
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var deviceTypes = await _deviceTypeRepo.GetAllAsync();
            var devicetypeDto = deviceTypes.Select(dt => dt.ToDeviceTypeDto());
            return Ok(devicetypeDto);
        }

        // GET: api/DeviceType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var deviceType = await _deviceTypeRepo.GetByIdAsync(id);
            if (deviceType == null)
            {
                return NotFound();
            }
            return Ok(deviceType.ToDeviceTypeDto());
        }

        // POST: api/DeviceType
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeviceTypeRequestDto createDto)
        {
            var devicetypeModel = createDto.toDeviceTypeFromCreateDto();
            await _deviceTypeRepo.CreateAsync(devicetypeModel);
            return CreatedAtAction(nameof(GetById), new { id = devicetypeModel.DeviceTypeId }, devicetypeModel.ToDeviceTypeDto());
        }

        // PUT: api/DeviceType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDeviceTypeRequestDto updateDto)
        {
            var deviceTypeModel = await _deviceTypeRepo.UpdateAsync(id, updateDto);
            if (deviceTypeModel == null)
            {
                return NotFound();
            }
            deviceTypeModel.Name = updateDto.Name;
            return Ok(deviceTypeModel.ToDeviceTypeDto());
        }

        // DELETE: api/DeviceType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deviceTypeModel = await _deviceTypeRepo.DeleteAsync(id);
            if (deviceTypeModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}