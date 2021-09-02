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
    public class PublicThingsController : ControllerBase
    {
        private sensoriandoContext _context; 
 
        public PublicThingsController(sensoriandoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable Get()
        {
            var result = from p in _context.Set<Plan>().Where(p => p.Ispublic == true)
                         from at in _context.Set<Accountsthing>().Where(at => at.IdAccountNavigation.IdPlan == p.Id)
                         from ts in _context.Set<Thingssensor>().Where(ts => ts.IdThing == at.IdThing )
                         select new {
                             ts.IdThingNavigation.Name,
                             at.IdAccountNavigation.City,
                             at.IdAccountNavigation.State,
                             at.IdAccountNavigation.Country,
                             ts.IdSensorNavigation,
                             ts.Thingssensorstags,
                         };

            return result;
        }
    }
}

