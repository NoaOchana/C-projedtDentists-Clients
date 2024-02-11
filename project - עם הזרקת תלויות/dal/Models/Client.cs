using System;
using System.Collections.Generic;

namespace dal.Models
{
    public partial class Client
    {
        public Client()
        {
            Queues = new HashSet<Queue>();
        }

        public string ClientId { get; set; } = null!;
        public string? ClientName { get; set; }
        public string? Hmo { get; set; }

        public virtual ICollection<Queue> Queues { get; set; }
    }
}
