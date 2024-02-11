using dal.DalApi;
using dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.DalImplementation
{
    public class ClientService : IClient
    {
        public async void Create(Client item)
        {
            if(item == null) throw new ArgumentNullException("item is null");
            manageDB db = new manageDB();
            db.Add(item);
            db.SaveChanges();
        }

        public async void Delete(Client item)
        {
            if(item == null) return;
            manageDB db = new manageDB();
            db.Remove(item);
            db.SaveChanges();
        }

        public List<Client> Read()
        {
            manageDB db = new manageDB();
            return db.Clients.ToList();
        }

        public async void Update(Client item)
        {
            if (item == null) throw new ArgumentNullException("item is null");
            manageDB db = new manageDB();
            db.Clients.Add(item);
            db.SaveChanges();
        }
    }
}
