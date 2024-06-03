using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMAPIGestorDeTareasMagicOficial.Data.Models;

public partial class DMPrioridad
{
    [Key]
    public int DMPrioridadId { get; set; }

    public string DMNombre { get; set; } = null!;

    public string DMDescripcion { get; set; } = null!;

    public virtual DMTarea? DMTarea { get; set; }
}
