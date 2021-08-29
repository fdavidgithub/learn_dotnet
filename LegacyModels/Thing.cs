using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.LegacyModels
{
    public partial class Thing
    {
        public Thing()
        {
            Accountsthings = new HashSet<Accountsthing>();
            Thingsparams = new HashSet<Thingsparam>();
            Thingssensors = new HashSet<Thingssensor>();
            Thingstags = new HashSet<Thingstag>();
        }

        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public string Name { get; set; }
        public Guid Uuid { get; set; }
        public bool Isrelay { get; set; }

        public virtual ICollection<Accountsthing> Accountsthings { get; set; }
        public virtual ICollection<Thingsparam> Thingsparams { get; set; }
        public virtual ICollection<Thingssensor> Thingssensors { get; set; }
        public virtual ICollection<Thingstag> Thingstags { get; set; }
    }
}
