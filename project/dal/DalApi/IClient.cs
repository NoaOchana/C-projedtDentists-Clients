using dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.DalApi
{
    internal interface IClient : ICrud<Client>
    {
        //Queue GetClientList();
    }
}
