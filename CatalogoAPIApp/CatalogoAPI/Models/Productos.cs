using System.ComponentModel.DataAnnotations;

namespace CatalogoAPI.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public int Precio { get; set; }
    }
}
