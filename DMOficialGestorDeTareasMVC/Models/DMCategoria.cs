using System.ComponentModel.DataAnnotations;

namespace DMOficialGestorDeTareasMVC.Models
{
    public class DMCategoria
    {
        [Key]
        public int DMCategoriaID { get; set; }

        [Required(ErrorMessage = "No puedes dejar estos campos vacios")]
        public string? DMNombre { get; set; }
        public string? DMDescripcion { get; set; }

        // Propiedad de navegación
        public DMTarea? DMTarea { get; set; }
    }
}
