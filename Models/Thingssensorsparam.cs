using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.Models
{
    public partial class Thingssensorsparam
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int IdThingsensor { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual Thingssensor IdThingsensorNavigation { get; set; }
    }
}
