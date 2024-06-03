using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMAPIGestorDeTareasMagicOficial.Data.Models;

public partial class DMCategoria
{
    [Key]
    public int DMCategoriaID { get; set; }

    public string DMNombre { get; set; } = null!;

    public string? DMDescripcion { get; set; }

    public virtual DMTarea? DMTarea { get; set; }
}
