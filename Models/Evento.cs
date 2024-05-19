

using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Evento
    {
        [Key] 
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdUbicacion { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public ICollection<Registro> Registros { get; set; } = new List<Registro>();
        public ICollection<Recurso> Recursos { get; set; } = new List<Recurso>();
    }
}
