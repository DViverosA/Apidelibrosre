using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Apidelibros.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string ISBN { get; set; }
        public int Autorid { get; set; }
        public Autor? autor { get; set; }
        public int Editorialid { get; set; }
        public Editorial? editorial { get; set; }
    }
}
