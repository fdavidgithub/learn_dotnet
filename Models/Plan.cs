using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.Models
{
    public partial class Plan
    {
        public Plan()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public string Name { get; set; }
        public bool? Ispublic { get; set; }
        public bool Istrigger { get; set; }
        public int Retation { get; set; }
        public double Vlhour { get; set; }
        public double Vltrigger { get; set; }
        public bool? Visible { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
