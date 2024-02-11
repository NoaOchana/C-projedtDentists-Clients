using dal.DalApi;
using dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.DalImplementation
{
    public class DentistService : IDentist
    {
        manageDB db;
        public DentistService(manageDB db)
        {
            this.db = db;
        }

        public async void Create(Dentist item)
        {
            if (item == null) throw new ArgumentNullException("item is null");
            db.Add(item);
            db.SaveChanges();
        }

        public async void Delete(Dentist item)
        {
            if (item == null) return;
            db.Remove(item);
            db.SaveChanges();
        }

        public async Task<List<Dentist>> Read()
        {
            return db.Dentists.ToList();
        }

        public async void Update(Dentist item)
        {
            if (item == null) throw new ArgumentNullException("item is null");
            db.Dentists.Add(item);
            db.SaveChanges();
        }
    }
}
