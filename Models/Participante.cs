using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Participante
    {
        [Key]
        public int IdParticipante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public ICollection<Registro> Registros { get; set; } = new List<Registro>();
    }
}
