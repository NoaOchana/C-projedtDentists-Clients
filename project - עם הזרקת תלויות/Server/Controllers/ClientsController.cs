using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bl;
using bl.Models;
using bl.Blimplementation;
using bl.BlApi;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        IClient clientService;
        public ClientsController(BLManager clientService)
        {
            this.clientService = clientService.Client;
        }

        [HttpGet]
        [Route("GetClientList")]
        public List<Client> GetClientList()
        {
            return clientService.Read().Result;
        }

        [HttpGet]
        [Route("GetClientById/id")]
        public Client GetClientByID(string id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id");
            }
            List<Client> clientList = clientService.Read().Result;
            Client client = clientList.Find( client => client.Id.Contains(id)); 
            return client;
        }

        [HttpPost]
        [Route("create/client")]
        public void Create(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client is null here");
            }
            else
            {
                clientService.Create(client);
            }
        }

        [HttpPost]
        [Route("delete/client")]
        public void Delete(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client is null here");
            }
            else
            {
                clientService.Delete(client);
            }
        }

    }
}
