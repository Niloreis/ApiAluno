using ApiMestre.Data.Contexts;
using ApiMestre.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMestre.Data.Repositories
{
    public class MestreRepository
    {
        public void Add(Mestre entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Mestre.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(Mestre entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }


        public void Delete(Mestre entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Mestre.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Mestre> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Mestre
                    .Include(a => a.Alunos)
                    .OrderBy(a => a.Nome)
                    .ToList();
            }
        }

        public Mestre GetById(Guid? id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Mestre
                    .Include(a => a.Alunos)
                    .Where(m => m.IdMestre == id)
                    .FirstOrDefault();
            }

        }
    }
}
