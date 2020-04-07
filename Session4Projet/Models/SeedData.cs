using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Session4Projet.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Session4ProjetContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Session4ProjetContext>>()))
            {
                // Look for any movies.
                if (context.Tetee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tetee.AddRange(
                    new Tetee
                    {
                        Title = "Petite compliquee",
                        Type = "gauche",
                        Technique = "Appuie sur la tete",
                        Heure = DateTime.Parse("03:25"),
                        Commentaire = "facile"
                        
                    },

                   new Tetee
                   {
                       Title = "petite matinal",
                       Type = "gauche",
                       Technique = "Appuie sur la tete",
                       Heure = DateTime.Parse("06:35"),
                       Commentaire = "fatiguante"

                   },

                    new Tetee
                    {
                        Title = "le dejuner",
                        Type = "gauche",
                        Technique = "virer le bebe de bord",
                        Heure = DateTime.Parse("09:25"),
                        Commentaire = "rapide et efficace"

                    },

                    new Tetee
                    {
                        Title = "le dinnere",
                        Type = "droit",
                        Technique = "aucune",
                        Heure = DateTime.Parse("12:25"),
                        Commentaire = "il navait pas faim"

                    }
                );
                context.SaveChanges();
            }
        }
    }
}