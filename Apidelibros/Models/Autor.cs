using System.ComponentModel.DataAnnotations;

namespace Apidelibros.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
