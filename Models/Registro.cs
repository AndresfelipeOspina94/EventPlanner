using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Registro
    {
        [Key]
        public int IdRegistro { get; set; }
        public int IdEvento { get; set; }
        public Evento Evento { get; set; }
        public int IdParticipante { get; set; }
        public Participante Participante { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
