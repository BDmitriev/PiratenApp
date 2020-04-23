using PiratenApp.Data;
using PiratenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Repositories
{
    public class SchiffRepository : ISchiffRepository
    {
        private ApplicationDbContext context;
        public SchiffRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Schiff> Schiffe => context.Schiffe;

        public void saveSchiff(Schiff schiff)
        {
            context.Schiffe.Add(schiff);
            context.SaveChanges();
        }

        public List<Schiff> GetSchiffeByName(IEnumerable<string> SchiffNamen)
        {
            List<Schiff> tempSchiffe = new List<Schiff>();
            SchiffNamen.ToList().ForEach(item =>
            {
                tempSchiffe.Add(
                       context.Schiffe.Where(schiff =>
                                                schiff.SchiffName == item).FirstOrDefault()
                    );
            });

            //DeleteSchiffeByName(tempSchiffe);

            return tempSchiffe;
        }

        public void DeleteSchiffeByName(IEnumerable<Schiff> Schiffe) 
        {
            Schiffe.ToList().ForEach(item =>
            {
                context.Schiffe.RemoveRange( Schiffe );
                   
            });
        }
        
    }
}
