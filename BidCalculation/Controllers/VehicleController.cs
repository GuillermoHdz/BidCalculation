using BidCalculation.Business.Services;
using BidCalculation.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BidCalculation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var vehicles = await _vehicleService.GetVehiclesAsync();
            var response = JsonConvert.SerializeObject(vehicles);
            return Ok(response);
        }

        [HttpGet("Types")]
        public async Task<IActionResult> GetAllTypesAsync()
        {
            var types = await _vehicleService.GetVehicleTypesAsync();
            return Ok(JsonConvert.SerializeObject(types));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Vehicle vehicle)
        {
            var calculations = await _vehicleService.AddVehicleAsync(vehicle);
            return Ok(JsonConvert.SerializeObject(calculations));
        }
    }
}
