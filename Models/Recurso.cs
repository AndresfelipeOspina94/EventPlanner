using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Recurso
    {
        [Key]
        public int IdRecurso { get; set; } 
        public int IdEvento { get; set; } 
        public Evento Evento { get; set; } = new Evento();
        public string NombreRecurso { get; set; }    
        public int Cantidad { get; set; } 
        public string Descripcion { get; set; } = string.Empty;
    }
}
