using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.LegacyModels
{
    public partial class Sensor
    {
        public Sensor()
        {
            Sensorsunits = new HashSet<Sensorsunit>();
            Thingssensors = new HashSet<Thingssensor>();
        }

        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sensorsunit> Sensorsunits { get; set; }
        public virtual ICollection<Thingssensor> Thingssensors { get; set; }
    }
}
