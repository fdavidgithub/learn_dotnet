using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.LegacyModels
{
    public partial class Thingsparam
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int IdThing { get; set; }

        public virtual Thing IdThingNavigation { get; set; }
    }
}
