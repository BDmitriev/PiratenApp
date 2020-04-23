using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Models.Viewmodels
{
    public class PiratIndexViewModel
    {
        public Pirat Pirat { get; set; }

        public IEnumerable<Pirat> Piraten { get; set; }

        public IEnumerable<Schiff> Schiffe { get; set; }

        
    }
}
