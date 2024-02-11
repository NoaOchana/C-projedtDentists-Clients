using bl.BlApi;
using bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal.DalImplementation;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic;

namespace bl.Blimplementation
{
    public class ClientService : IClient
    {
        public async void Create(Client item)
        {
            dal.DalImplementation.ClientService clientService = new();
            dal.Models.Client client = new dal.Models.Client();
            client.ClientId = item.Id;
            client.ClientName = item.Name;
            client.Hmo = item.HMO;
            clientService.Create(client);
        }

        public async void Delete(Client item)
        {
            if(item == null) return;
            dal.DalImplementation.ClientService clientService = new();
            dal.Models.Client c = new() { ClientId = item.Id, ClientName = item.Name, Hmo = item.HMO };
            clientService.Delete(c);
        }

        public List<Client> Read()
        {
            dal.DalImplementation.ClientService cs = new();
            List<Client> clientList = new List<Client>();
            cs.Read().ForEach(client => {
                Client c = new Client() { Name = client.ClientName, Id = client.ClientId, HMO = client.Hmo/*, firstDentalCare = GetFirstDentalCare()*/ };
                clientList.Add(c);
            });
            return clientList;
        }

        public async void Update(Client item)
        {
            throw new NotImplementedException();
        }

        //public DateTime GetNextDentalCare()
        //{
        //DateTime dateTime = DateTime.Now;
        //DateTime minTime = DateTime.MaxValue;
        //dal.Models.Client client = new();
        //var nextVisit = from q in client.Queues
        //                where q.QueueDate > dateTime && q.QueueDate < minTime
        //                select q.QueueDate;
        //return nextVisit.FirstOrDefault();
        //}

        public DateTime GetNextDentalCare(Client client)
        {
            return client.FirstCare.Date;
        }
    }
}
