using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Session4Projet.Models
{
    public class TeteeTypeViewModel
    {
        public List<Tetee> Tetees { get; set; }
        public SelectList Types { get; set; }
        public string TeteeType { get; set; }
        public string SearchString { get; set; }
    }
}
