using dal.DalApi;
using dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.DalImplementation
{
    public class ClientService : IClient
    {
        manageDB db;
        public ClientService(manageDB db)
        {
            this.db = db;
        }
        public async void Create(Client item)
        {
            if(item == null) throw new ArgumentNullException("item is null");
            db.Add(item);
            db.SaveChanges();
        }

        public async void Delete(Client item)
        {
            if (item == null) return;

            var existingEntity = db.Clients.Find(item.ClientId); // Retrieve the entity from the context
            if (existingEntity != null)
            {
                db.Clients.Remove(existingEntity); // Mark the entity for deletion
                db.SaveChanges(); // Save changes to delete the entity
            }



            //db.Remove(item);
            //db.SaveChanges();
        }

        public async Task<List<Client>> Read()
        {
            return db.Clients.ToList();
        }

        public async void Update(Client item)
        {
            if (item == null) throw new ArgumentNullException("item is null");
            db.Clients.Add(item);
            db.SaveChanges();
        }
    }
}
