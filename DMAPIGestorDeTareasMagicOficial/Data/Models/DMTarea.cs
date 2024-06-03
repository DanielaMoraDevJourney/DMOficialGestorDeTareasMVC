using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMAPIGestorDeTareasMagicOficial.Data.Models;

public partial class DMTarea

{
    [Key]
    public int DMTareaID { get; set; }

    public string DMTitulo { get; set; } = null!;

    public string DMDescripcion { get; set; } = null!;

    public DateTime DMFechaVencimiento { get; set; }

    public int DMPrioridadID { get; set; }

    public int DMCategoriaID { get; set; }

    public virtual DMCategoria DMCategoria { get; set; } = null!;

    public virtual DMPrioridad DMPrioridad { get; set; } = null!;
}
