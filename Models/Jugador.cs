using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Jugador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJugador { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Password { get; set; }
    }
}