namespace WebApplication1.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }

        public int IdJugador { get; set; }

        public DateTime FechaInicio { get; set; }

        public int DiaActual { get; set; }

        public int Conocimiento { get; set; }

        public int Energia { get; set; }

        public int Estres { get; set; }

        public int Relaciones { get; set; }

        public string Estado { get; set; }
    }
}
