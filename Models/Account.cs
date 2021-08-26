using System;
using System.Collections.Generic;

#nullable disable

namespace sensoriando_webservice.Models
{
    public partial class Account
    {
        public Account()
        {
            Accountsthings = new HashSet<Accountsthing>();
        }

        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int IdPlan { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool? Status { get; set; }

        public virtual Plan IdPlanNavigation { get; set; }
        public virtual ICollection<Accountsthing> Accountsthings { get; set; }
    }
}
