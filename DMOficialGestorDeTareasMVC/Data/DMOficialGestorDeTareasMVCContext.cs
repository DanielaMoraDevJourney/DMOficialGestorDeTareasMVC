using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DMOficialGestorDeTareasMVC.Models;

    public class DMOficialGestorDeTareasMVCContext : DbContext
    {
        public DMOficialGestorDeTareasMVCContext (DbContextOptions<DMOficialGestorDeTareasMVCContext> options)
            : base(options)
        {
        }

        public DbSet<DMOficialGestorDeTareasMVC.Models.DMCategoria> DMCategoria { get; set; } = default!;

public DbSet<DMOficialGestorDeTareasMVC.Models.DMPrioridad> DMPrioridad { get; set; } = default!;

public DbSet<DMOficialGestorDeTareasMVC.Models.DMTarea> DMTarea { get; set; } = default!;
    }
