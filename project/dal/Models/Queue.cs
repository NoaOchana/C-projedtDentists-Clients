using System;
using System.Collections.Generic;

namespace dal.Models
{
    public partial class Queue
    {
        public string QueueId { get; set; } = null!;
        public string? ClientId { get; set; }
        public string? DentistId { get; set; }
        public DateTime? QueueDate { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Dentist? Dentist { get; set; }
    }
}
