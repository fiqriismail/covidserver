using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Services;

namespace ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbServiceController : ControllerBase
    {
        private readonly StatisticsService _service;

        public DbServiceController(StatisticsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Get()
        {
            await _service.GetAndPopulate();
            return Ok(new {message = "All good", status = 1});
        }
    }
}