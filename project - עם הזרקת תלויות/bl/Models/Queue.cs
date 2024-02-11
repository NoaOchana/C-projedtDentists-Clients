using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl.Models
{
    public class Queue
    {
        public string QueueId { get; set; }
        public string ClientId { get; set; }
        public string DentistId { get; set; }
        public DateTime QueueDate { get; set; }
    }
}
