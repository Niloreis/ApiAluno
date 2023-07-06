using ApiMestre.Data.Contexts;
using ApiMestre.Data.Entities;
using ApiMestre.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPresenca.Data.Repositories
{
  
          public class PresencaRepository : IRepository<Presenca>
        {
            public void Add(Presenca entity)
            {
                using (var dataContext = new DataContext())
                {
                    dataContext.Presenca.Add(entity);
                    dataContext.SaveChanges();
                }

            }

            public void Delete(Presenca entity)
            {
                using (var dataContext = new DataContext())
                {
                    dataContext.Entry(entity).State = EntityState.Modified;
                    dataContext.SaveChanges();
                }

            }

            public List<Presenca> GetAll()
            {
            using (var dataContext = new DataContext())
            {
                return dataContext.Presenca
                    .Include(a => a.Alunos)
                     
                    .ToList();
            }

        }

        public Presenca GetById(Guid? id)
            {
            using (var dataContext = new DataContext())
            {
                return dataContext.Presenca
                       .Include(a => a.Alunos)
                        .Where(c => c.IdPresenca == id)
                        .FirstOrDefault();
            }

        }

        public void Update(Presenca entity)
            {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }

        }
    }


    }

