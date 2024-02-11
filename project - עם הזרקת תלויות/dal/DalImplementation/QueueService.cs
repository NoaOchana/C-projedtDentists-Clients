using dal.DalApi;
using dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.DalImplementation
{
    public class QueueService : IQueue
    {
        manageDB db;
        public QueueService(manageDB db)
        {
            this.db = db;
        }


        public async void Create(Queue item)
        {
            if (item == null) throw new ArgumentNullException("item is null");
            db.Add(item);
            db.SaveChanges();
        }

        public async void Delete(Queue item)
        {
            if (item == null) return;
            db.Remove(item);
            db.SaveChanges();
        }

        public async Task<List<Queue>> Read()
        {
            return db.Queues.ToList();
        }

        public void Update(Queue item)
        {
            if (item == null) throw new ArgumentNullException("item is null");
            db.Queues.Add(item);
            db.SaveChanges();
        }
    }
}
