using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.Models
{
    public partial class Payload
    {
        public Payload()
        {
            Thingssensorsdata = new HashSet<Thingssensorsdatum>();
        }

        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int IdConnection { get; set; }
        public string Payload1 { get; set; }

        public virtual Connection IdConnectionNavigation { get; set; }
        public virtual ICollection<Thingssensorsdatum> Thingssensorsdata { get; set; }
    }
}
