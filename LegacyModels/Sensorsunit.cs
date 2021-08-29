using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.LegacyModels
{
    public partial class Sensorsunit
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int IdSensor { get; set; }
        public string Name { get; set; }
        public string Initial { get; set; }
        public short? Precision { get; set; }
        public bool Isdefault { get; set; }
        public string Expression { get; set; }

        public virtual Sensor IdSensorNavigation { get; set; }
    }
}
