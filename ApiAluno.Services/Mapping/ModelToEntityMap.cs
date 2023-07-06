using ApiAluno.Services.Models;
using ApiMestre.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiMestre.Services.Mappings
{
    /// <summary>
    /// Mapear transferencias de dados de Models para Entities
    /// </summary>
    public class ModelToEntityMap : Profile
    {
        //método construtor
        public ModelToEntityMap()
        {
            CreateMap<MestrePostModel, Mestre>()
                .AfterMap((src, dest) =>
                {
                    dest.IdMestre = Guid.NewGuid();
                    
                });
            CreateMap<MestrePutModel, Mestre>()
                .AfterMap((src, dest) =>
              {
               
                 
              });

            CreateMap<AlunoPostModel, Alunos>()
                .AfterMap((src, dest) =>
                {
                    dest.IdAluno = Guid.NewGuid();
                  
                });

            CreateMap<AlunoPutModel, Alunos>()
                  .AfterMap((src, dest) =>
                  {
                      
                      
                  });

            CreateMap<PresencaPostModels, Presenca>()
               .AfterMap((src, dest) =>
               {
                   dest.IdPresenca = Guid.NewGuid();

               });
            CreateMap<PresencaPutModel, Presenca>()
                .AfterMap((src, dest) =>
                {


                });

        }
    }
}

