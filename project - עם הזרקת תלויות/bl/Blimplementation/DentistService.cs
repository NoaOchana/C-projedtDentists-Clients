using bl.BlApi;
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
    public class DentistService : bl.BlApi.IDentist
    {

        dal.DalApi.IDentist dentistService;

        public DentistService(DalManager dentistService)
        {
            this.dentistService = dentistService.dentist;
        }

        public async void Create(Dentist item)
        {
            dal.Models.Dentist dentist = new dal.Models.Dentist();
            dentist.DentistId = item.Id;
            dentist.DentistName = item.Name;
            dentistService.Create(dentist);
        }

        public async void Delete(Dentist item)
        {
            if (item == null) return;
            dal.Models.Dentist d = new() { DentistId = item.Id, DentistName = item.Name };
            dentistService.Delete(d);
        }

        public async Task<List<Dentist>> Read()
        {
            List<Dentist> dentistList = new List<Dentist>();
            dentistService.Read().Result.ForEach(dentist => {
                Dentist d = new Dentist() { Name = dentist.DentistName, Id = dentist.DentistId };
                dentistList.Add(d);
            });
            return dentistList;
        }

        public async void Update(Dentist item)
        {
            throw new NotImplementedException();
        }
    }
}
