using System;
using System.Collections.Generic;

namespace dal.Models
{
    public partial class Dentist
    {
        public Dentist()
        {
            Queues = new HashSet<Queue>();
        }

        public string DentistId { get; set; } = null!;
        public string? DentistName { get; set; }

        public virtual ICollection<Queue> Queues { get; set; }
    }
}
