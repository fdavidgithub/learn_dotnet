using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sensoriando_webservice.Models;

namespace sensoriando_webservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorController : ControllerBase
    {
        private sensoriandoContext _context; 
 
        public SensorController(sensoriandoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Sensor> Get()
        {
            return _context.Sensors;
        }
    }
}

