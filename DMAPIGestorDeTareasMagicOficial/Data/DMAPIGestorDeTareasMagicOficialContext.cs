using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DMAPIGestorDeTareasMagicOficial.Data.Models;

namespace DMAPIGestorDeTareasMagicOficial.Data
{
    public class DMAPIGestorDeTareasMagicOficialContext : DbContext
    {
        public DMAPIGestorDeTareasMagicOficialContext (DbContextOptions<DMAPIGestorDeTareasMagicOficialContext> options)
            : base(options)
        {
        }

        public DbSet<DMAPIGestorDeTareasMagicOficial.Data.Models.DMTarea> DMTarea { get; set; } = default!;
        public DbSet<DMAPIGestorDeTareasMagicOficial.Data.Models.DMCategoria> DMCategoria { get; set; } = default!;
        public DbSet<DMAPIGestorDeTareasMagicOficial.Data.Models.DMPrioridad> DMPrioridad { get; set; } = default!;
    }
}
