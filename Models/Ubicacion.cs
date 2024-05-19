using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Ubicacion
    {
        [Key]
        public int IdUbicacion { get; set; }
        public string NombreUbicacion { get; set; }
        public int Capacidad { get; set; }
        public string Direccion { get; set; }
        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
