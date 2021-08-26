using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.Models
{
    public partial class Thingssensor
    {
        public Thingssensor()
        {
            Thingssensorsdata = new HashSet<Thingssensorsdatum>();
            Thingssensorsparams = new HashSet<Thingssensorsparam>();
            Thingssensorstags = new HashSet<Thingssensorstag>();
        }

        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int IdThing { get; set; }
        public int IdSensor { get; set; }

        public virtual Sensor IdSensorNavigation { get; set; }
        public virtual Thing IdThingNavigation { get; set; }
        public virtual ICollection<Thingssensorsdatum> Thingssensorsdata { get; set; }
        public virtual ICollection<Thingssensorsparam> Thingssensorsparams { get; set; }
        public virtual ICollection<Thingssensorstag> Thingssensorstags { get; set; }
    }
}
