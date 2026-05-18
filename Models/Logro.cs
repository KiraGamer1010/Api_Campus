namespace WebApplication1.Models
{
    public class Logro
    {
        public int Id { get; set; }

        public string NombreLogro { get; set; }

        public string Descripcion { get; set; }

        public int IdTema { get; set; }

        public Tema Tema { get; set; }
    }
}
