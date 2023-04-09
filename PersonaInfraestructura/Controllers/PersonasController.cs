using Microsoft.AspNetCore.Mvc;
using PersonaInfraestructura.Models;
using PersonaInfraestructura.Sevices;

namespace PersonaInfraestructura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaServices _context;

        public PersonasController(IPersonaServices context)
        {
            _context = context;
        }

        //GET: api/Personas
        [HttpGet]
        public IActionResult GetPersonas()
        {
            return Ok(_context.GetPersonas());
        }

        //GET: api/Personas/5
        [HttpGet("{id}")]
        public IActionResult GetPersonas(int id)
        {
            var persona = _context.GetPersonaById(id);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }


        //PUT: api/Personas/5
        [HttpPut("{id}")]
        public IActionResult PutPersona(int id, Persona newPersonaRecords)
        {
            if (newPersonaRecords.PerdonsaID != id) return BadRequest(ModelState);



            Persona personaOldRecord = _context.GetPersonaById(id);

            if (personaOldRecord == null) return NotFound();

            Persona personaUpdate = _context.PutPersona(newPersonaRecords);

            return Ok(personaUpdate);
        }

        // POST: api/Personas
        [HttpPost]
        public ActionResult PostPersona(Persona persona)
        {

            if (_context.GetPersonaById(persona.PerdonsaID) != null)
            {
                return BadRequest(ModelState);
            }
            var personaPosted = _context.PostPersona(persona);
            return Ok(personaPosted);

        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public IActionResult DeletePersona(int id)
        {
            if (_context.GetPersonas() == null)
            {
                return NotFound();
            }
            var persona = _context.GetPersonaById(id);
            if (persona == null)
            {
                return NotFound();
            }

            IEnumerable<Persona> ListUpdate = _context.DeletePersona(persona);


            return Ok(ListUpdate);
        }


    }
}
