using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIGestorDeTareasDM.Models
{
    public class DMTarea
    {
        public int DMTareaID { get; set; }
        public string? DMTitulo { get; set; }
        public string? DMDescripcion { get; set; }
        public DateTime DMFechaVencimiento { get; set; }
        public int DMPrioridadID { get; set; }
        public DMPrioridad? DMPrioridad { get; set; }
        public int DMCategoriaID { get; set; }
        public DMCategoria? DMCategoria { get; set; }
    }
}
