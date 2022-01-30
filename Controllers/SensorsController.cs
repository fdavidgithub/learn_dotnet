using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sensoriando_webservice.LegacyModels;

namespace sensoriando_webservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorsController : ControllerBase
    {
        private sensoriandoContext _context; 
 
        public SensorsController(sensoriandoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable Get()
        {
            var result = from s in _context.Set<Sensor>()
                         select new {
                             s.Id,
                             s.Name,
                         };

            return result;
        }
/*
        public IEnumerable<Sensor> Get()
        {
            return _context.Sensors;
        }
*/        
    }
}

