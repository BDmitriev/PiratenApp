using PiratenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Repositories
{
    public interface IPiratSchiffRepository
    {
        public IQueryable<PiratSchiff> PiratSchiffe { get; }
       

        public void savePiratSchiff(PiratSchiff piratSchiff);
    }
}
