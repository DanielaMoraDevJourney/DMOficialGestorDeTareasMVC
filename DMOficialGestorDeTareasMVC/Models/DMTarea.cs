using System.ComponentModel.DataAnnotations;

namespace DMOficialGestorDeTareasMVC.Models
{
    public class DMTarea
    {
        [Key]
        public int DMTareaID { get; set; }

        [Required(ErrorMessage = "El Titulo es obligatorio")]
        public string? DMTitulo { get; set; }

        [Required(ErrorMessage = "La Descripcion es obligatoria")]
        public string? DMDescripcion { get; set; }

        [Required(ErrorMessage = "La Fecha de Vencimiento es obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DMFechaVencimiento { get; set; }

        public int DMPrioridadID { get; set; }
        public DMPrioridad? DMPrioridad { get; set; }

        public int DMCategoriaID { get; set; }

        public DMCategoria? DMCategoria { get; set; }
    }
}
