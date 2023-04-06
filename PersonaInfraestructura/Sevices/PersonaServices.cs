using PersonaInfraestructura.Models;

namespace PersonaInfraestructura.Sevices
{
    public class PersonaServices : IPersonaServices
    {

        private List<Persona> _listPersonas = new List<Persona>()
            {
                new Persona(){PerdonsaID= 1, Nombre="Juan", Apellido="Palau" , Edad=45, Casado=false},
                new Persona(){PerdonsaID= 4, Nombre="Izaskun", Apellido="Mena" , Edad=15, Casado=false},
                new Persona(){PerdonsaID= 3, Nombre="Natalia", Apellido="Junquers" , Edad=35, Casado=true},
                new Persona(){PerdonsaID= 8, Nombre="Xativa", Apellido="Ramon" , Edad=5, Casado=false},
                new Persona(){PerdonsaID= 5, Nombre="Aldo", Apellido="Jarez" , Edad=18, Casado=true},
                new Persona(){PerdonsaID= 2, Nombre="Ali", Apellido="Perez" , Edad=75, Casado=true}
            };

        public IEnumerable<Persona> DeletePersona(Persona persona)
        {
            _listPersonas.Remove(persona);

            return _listPersonas;
        }

        public Persona? GetPersonaById(int id)
        {
            return _listPersonas.FirstOrDefault(x => x.PerdonsaID == id);
        }

        public IEnumerable<Persona> GetPersonas()
        {
            return _listPersonas;
        }

        public Persona PostPersona(Persona persona)
        {
            _listPersonas.Add(persona);

            return GetPersonaById(persona.PerdonsaID);

        }

        public Persona PutPersona(Persona persona)
        {
            Persona p1 = GetPersonaById(persona.PerdonsaID);

            _listPersonas.FirstOrDefault(x => x.PerdonsaID == persona.PerdonsaID).Nombre = p1.Nombre + " " + persona.Nombre;
            _listPersonas.FirstOrDefault(x => x.PerdonsaID == persona.PerdonsaID).Apellido = p1.Apellido + " " + persona.Apellido;
            _listPersonas.FirstOrDefault(x => x.PerdonsaID == persona.PerdonsaID).Edad = persona.Edad;
            _listPersonas.FirstOrDefault(x => x.PerdonsaID == persona.PerdonsaID).Casado = persona.Casado;

            var aux = _listPersonas;

            return p1;
        }
    }
}
