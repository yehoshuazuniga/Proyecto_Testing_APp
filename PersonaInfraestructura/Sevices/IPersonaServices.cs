using PersonaInfraestructura.Models;

namespace PersonaInfraestructura.Sevices
{
    public interface IPersonaServices
    {

        public IEnumerable<Persona> GetPersonas();

        public Persona? GetPersonaById(int id);

        public Persona PostPersona(Persona persona);

        public Persona PutPersona( Persona persona);

        public IEnumerable<Persona> DeletePersona(Persona persona);
    }
}
