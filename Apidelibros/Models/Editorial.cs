using System.ComponentModel.DataAnnotations;

namespace Apidelibros.Models
{
    public class Editorial
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
