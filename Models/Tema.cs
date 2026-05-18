using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Tema
    {
        public int Id { get; set; }
        public string NombreTema { get; set; }
        [JsonIgnore]
        public ICollection<Logro>? Logros { get; set; }

    }
}
