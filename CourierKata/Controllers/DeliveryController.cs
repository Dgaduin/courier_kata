using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CourierKata.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly ILogger<DeliveryController> _logger;

        public DeliveryController(ILogger<DeliveryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
