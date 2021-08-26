using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.Models
{
    public partial class Thingstag
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int IdThing { get; set; }
        public string Name { get; set; }

        public virtual Thing IdThingNavigation { get; set; }
    }
}
