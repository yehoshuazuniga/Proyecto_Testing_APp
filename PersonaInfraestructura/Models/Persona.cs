using System.ComponentModel.DataAnnotations;

namespace PersonaInfraestructura.Models
{

    public class Persona
    {
        public int PerdonsaID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public bool Casado { get; set; }
    }

   
}
