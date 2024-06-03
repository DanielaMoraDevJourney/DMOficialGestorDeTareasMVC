using System.ComponentModel.DataAnnotations;

namespace DMOficialGestorDeTareasMVC.Models
{
    public class DMPrioridad
    {
        [Key]
        public int DMPrioridadID { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string? DMNombre { get; set; }

        [Required(ErrorMessage = "La Descripcion es obligatoria")]
        public string? DMDescripcion { get; set; }

        //cf
        public DMTarea? DMTarea { get; set; }
    }
}
