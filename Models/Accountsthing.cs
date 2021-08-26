using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.Models
{
    public partial class Accountsthing
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int IdAccount { get; set; }
        public int IdThing { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
        public virtual Thing IdThingNavigation { get; set; }
    }
}
