using bl.BlApi;
using dal.DalApi;
using bl.Blimplementation;
using dal.DalImplementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;

namespace bl
{
    public class BLManager
    {
        public BlApi.IClient Client { get; }
        public BlApi.IDentist Dentist { get; }
        public BlApi.IQueue Queue { get; }

        public BLManager()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddSingleton<DalManager>();
            serviceDescriptors.AddSingleton<BlApi.IClient, bl.Blimplementation.ClientService>();
            serviceDescriptors.AddSingleton<BlApi.IDentist, bl.Blimplementation.DentistService>();
            serviceDescriptors.AddSingleton<BlApi.IQueue, bl.Blimplementation.QueueService>();

            var provider = serviceDescriptors.BuildServiceProvider();

            Client = provider.GetRequiredService<BlApi.IClient>();
            Dentist = provider.GetRequiredService<BlApi.IDentist>();
            Queue = provider.GetRequiredService<BlApi.IQueue>();
        }
    }
}
