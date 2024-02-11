using bl;
using bl.BlApi;
using bl.Models;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistsController : ControllerBase
    {
        IDentist dentistService;
        public DentistsController(BLManager dentistService)
        {
            this.dentistService = dentistService.Dentist;
        }

        [HttpGet]
        [Route("GetDentistList")]
        public List<Dentist> GetDentistList()
        {
            return dentistService.Read().Result;
        }

        [HttpGet]
        [Route("GetDentistById/id")]
        public Dentist GetDentistByID(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            List<Dentist> dentistList = dentistService.Read().Result;
            Dentist dentist = dentistList.Find(dentist => dentist.Id.Contains(id));
            return dentist;
        }

        [HttpPost]
        [Route("create/dentist")]
        public void Create(Dentist dentist)
        {
            if (dentist == null)
            {
                throw new ArgumentNullException("dentist is null here");
            }
            else
            {
                dentistService.Create(dentist);
            }
        }

        [HttpDelete]
        [Route("delete/dentist")]
        public void Delete(Dentist dentist)
        {
            if (dentist == null)
            {
                throw new ArgumentNullException("dentist is null here");
            }
            else
            {
                dentistService.Delete(dentist);
            }
        }
    }
}
