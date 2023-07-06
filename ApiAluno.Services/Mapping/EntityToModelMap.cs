using ApiAluno.Services.Models;
using ApiMestre.Data.Entities;
using AutoMapper;


namespace ApiAluno.Services.Mapping
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Mestre, MestreGetModel>();
            CreateMap<Alunos, AlunoGetModel>();
            CreateMap<Presenca, PresencaGetModel>();


        }
    }
}

