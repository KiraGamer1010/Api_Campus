namespace WebApplication1.Models
{
    public class Pregunta
    {
        public int IdPregunta { get; set; }

        public int IdTema { get; set; }

        public string PreguntaTexto { get; set; }

        public string OpcionA { get; set; }

        public string OpcionB { get; set; }

        public string OpcionC { get; set; }

        public string OpcionD { get; set; }

        public string Correcta { get; set; }

        public int Puntos { get; set; }
    }
}
