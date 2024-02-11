using bl.Models;
using dal;
using dal.DalImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl.Blimplementation
{
    public class QueueService : bl.BlApi.IQueue
    {
        dal.DalApi.IQueue queueService;

        public QueueService(DalManager queueService)
        {
            this.queueService = queueService.queue;
        }

        public async void Create(Queue item)
        {
            dal.Models.Queue queue = new dal.Models.Queue();
            queue.QueueId = item.QueueId;
            queueService.Create(queue);
        }

        public async void Delete(Queue item)
        {
            if (item == null) return;
            dal.Models.Queue q = new() { QueueId = item.QueueId };
            queueService.Delete(q);
        }

        public async Task<List<Queue>> Read()
        {
            List<Queue> queuetList = new List<Queue>();
            queueService.Read().Result.ForEach(queue => {
                Queue q = new Queue() { QueueId = queue.QueueId };
                queuetList.Add(q);
            });
            return queuetList;
        }

        public async void Update(Queue item)
        {
            throw new NotImplementedException();
        }
    }
}
