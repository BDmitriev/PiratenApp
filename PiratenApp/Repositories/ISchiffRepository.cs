using PiratenApp.Data;
using PiratenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Repositories
{
    public interface ISchiffRepository
    {
        public IQueryable<Schiff> Schiffe { get; }

        public void saveSchiff(Schiff schiff);
    }
}
