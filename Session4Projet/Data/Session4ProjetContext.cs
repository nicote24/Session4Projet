using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Session4Projet.Models
{
    public class Session4ProjetContext : DbContext
    {
        public Session4ProjetContext (DbContextOptions<Session4ProjetContext> options)
            : base(options)
        {
        }

        public DbSet<Session4Projet.Models.Tetee> Tetee { get; set; }
    }
}
