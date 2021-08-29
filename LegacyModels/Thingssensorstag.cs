using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.LegacyModels
{
    public partial class Thingssensorstag
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int IdThingsensor { get; set; }
        public string Name { get; set; }

        public virtual Thingssensor IdThingsensorNavigation { get; set; }
    }
}
