using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bl;
using bl.Models;
using bl.Blimplementation;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpGet]
        [Route("GetClientList")]
        public List<Client> GetClientList()
        {
            bl.Blimplementation.ClientService clientService = new();
            return clientService.Read();
        }

        [HttpGet]
        [Route("GetClientById/id")]
        public Client GetClientByID(string id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id");
            }
            bl.Blimplementation.ClientService clientService = new();
            List<Client> clientList = clientService.Read();
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
                bl.Blimplementation.ClientService clientService = new();
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
                bl.Blimplementation.ClientService bcs = new();
                bcs.Delete(client);
            }
        }

    }
}
