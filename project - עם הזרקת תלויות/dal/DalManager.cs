using dal.DalApi;
using dal.DalImplementation;
using dal.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal
{ 
    public class DalManager
    {
        public manageDB MDB { get; }
        public IClient client { get; }
        public IDentist dentist { get; }
        public IQueue queue { get; }
        public DalManager()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddSingleton<IClient, ClientService>();
            serviceDescriptors.AddSingleton<IDentist, DentistService>();
            serviceDescriptors.AddSingleton<IQueue, QueueService>();
            serviceDescriptors.AddSingleton<manageDB>();

            var provider = serviceDescriptors.BuildServiceProvider();

            MDB = provider.GetRequiredService<manageDB>();
            client = provider.GetRequiredService<IClient>();
            dentist = provider.GetRequiredService<IDentist>();
            queue = provider.GetRequiredService<IQueue>();
        }
    }
}
