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
    public class AlunoRepository : IRepository<Alunos>
    {
        /// <summary>
        /// Repositório de dados para Categoria
        /// </summary>
      
            public void Add(Alunos entity)
            {
                using (var dataContext = new DataContext())
                {
                    dataContext.Alunos.Add(entity);
                    dataContext.SaveChanges();
                }
            }

            public void Update(Alunos entity)
            {
                using (var dataContext = new DataContext())
                {
                    dataContext.Entry(entity).State = EntityState.Modified;
                    dataContext.SaveChanges();
                }
            }

            public void Delete(Alunos entity)
            {
                using (var dataContext = new DataContext())
                {
                    dataContext.Alunos.Remove(entity);
                    dataContext.SaveChanges();
                }
            }

            public List<Alunos> GetAll()
            {
                using (var dataContext = new DataContext())
                {
                    return dataContext.Alunos
                        .Include(a => a.Mestre)
                        .OrderBy(c => c.Nome)
                        .ToList();
                }
            }

            public Alunos GetById(Guid? id)
            {
                using (var dataContext = new DataContext())
                {
                    return dataContext.Alunos
                       .Include(a =>a.Mestre)
                        .Where(c => c.IdAluno == id)
                        .FirstOrDefault();
                }

            }
        }
    }

   
