using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.Models
{
    public partial class Thingssensorsdatum
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int IdPayload { get; set; }
        public int IdThingsensor { get; set; }
        public DateTime Dtread { get; set; }
        public double? Value { get; set; }
        public string Message { get; set; }

        public virtual Payload IdPayloadNavigation { get; set; }
        public virtual Thingssensor IdThingsensorNavigation { get; set; }
    }
}
