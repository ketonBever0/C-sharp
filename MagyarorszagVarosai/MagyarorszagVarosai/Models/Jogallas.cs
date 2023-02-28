using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MagyarorszagVarosai.Models
{
    public partial class Jogallas
    {
        public Jogallas()
        {
            Telepulesek = new HashSet<Telepulesek>();
        }

        public int Suly { get; set; }
        public string Jogallas1 { get; set; }

        public virtual ICollection<Telepulesek> Telepulesek { get; set; }
    }
}
