using PiratenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Repositories
{
    public interface IPiratRepository
    {
        public IQueryable<Pirat> Piraten{ get; }

        public void savePirat(Pirat pirat);
    }
}
