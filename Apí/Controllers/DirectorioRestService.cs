using Apí.DataAccess.Interfaces;
using Apí.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apí.Controllers
{
    [ApiController]
    [Route("Personas")]
    public class DirectorioRestService : ControllerBase
    {

        private readonly IPersonaRepository<Persona> _context;

        public DirectorioRestService(IPersonaRepository<Persona> context)
        {
            _context=context;
        }

        [HttpGet]
        [Route("getPersonas")]
        public List<Persona> getPersonas()
        {         
            return _context.findPersonas();
                  
        }
        [HttpGet]
        [Route("getPersonaById")]
        public Persona getPersonaById(int idPersona)
        {
            return _context.findPersonaByIdentificacion(idPersona);
        }
        [HttpPost]
        [Route("insertPersona")]
        public Persona insertPersona(Persona persona)
        {
            return _context.storagePersona(persona);   
        }


        [HttpDelete]
        [Route("deletePersona")]
        public Persona deletePersona(int idPersona)
        {
            return _context.deletePersonaByIdentificacion(idPersona);
        }


    }
}
