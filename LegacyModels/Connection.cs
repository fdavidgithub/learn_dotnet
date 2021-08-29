using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.LegacyModels
{
    public partial class Connection
    {
        public Connection()
        {
            Payloads = new HashSet<Payload>();
        }

        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int Qos { get; set; }
        public bool Retained { get; set; }
        public string Topic { get; set; }

        public virtual ICollection<Payload> Payloads { get; set; }
    }
}
