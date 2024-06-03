using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIGestorDeTareasDM.Models
{
    public class DMPrioridad
    {
        public int DMPrioridadID { get; set; }
        public string? DMNombre { get; set; }
        public string? DMDescripcion { get; set; }
        public DMTarea? DMTarea { get; set; }
    }
}
