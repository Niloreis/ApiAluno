using ApiAluno.Services.Models;
using ApiMestre.Data.Entities;
using ApiMestre.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace ApiAluno.Services.Controllers
{
    //[Authorize]     
    [Route("api/[controller]")]
    [ApiController]
    public class MestreController : ControllerBase
    {  
        //atributo
        private readonly IMapper _mapper;

        //construtor para inicializar os atributos da classe
        public MestreController(IMapper mapper)
        {
            _mapper = mapper;
        }   


        /// <summary>
        /// Serviço para cadastro de alunos na API
        /// </summary>
        [HttpPost]
        public IActionResult Post(MestrePostModel model)
        {
            try
            {
                var mestre = _mapper.Map<Mestre>(model);

                var mestreRepository = new MestreRepository();
                mestreRepository.Add(mestre);

                //HTTP 201 (CREATED)
                return StatusCode(201, new { mensagem = "Mestre cadastrado com sucesso.",

                categoria = _mapper.Map<MestreGetModel>(mestre)

                });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = "Falha ao cadastrar o mestre: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para edição de alunos na API
        /// </summary>
        [HttpPut]
        public IActionResult Put(MestrePutModel model)
        {
            try
            {
                var mestreRepository = new MestreRepository();

                if (mestreRepository.GetById(model.IdMestre) == null)
                    return StatusCode(404,new { mensagem = "mestre não encontrado." });

                var mestre = _mapper.Map<Mestre>(model);
                mestreRepository.Update(mestre);

                //HTTP 200 (OK)
                return StatusCode(200, new
                {
                    mensagem = "mestre atualizada com sucesso.",
                    mestre = _mapper.Map<MestreGetModel>(mestre)
                });
            }



            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Falha ao atualizar mestre: "+ e.Message});
            }

        }
        /// <summary>
        /// Serviço para exclusão de alunos na API
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {

            try
            {
                var mestreRepository = new MestreRepository();
                var mestre = mestreRepository.GetById(id);

                if (mestre == null)
                    return StatusCode(404,new { mensagem = "mestre não encontrada." });

                mestreRepository.Delete(mestre);

                //HTTP 200 (OK)
                return StatusCode(200, new
                {
                    mensagem = "Mestre excluída com sucesso.",
                    mestre = _mapper.Map<MestreGetModel>(mestre)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Falha ao excluir mestre: "+ e.Message});
            }

        }



        /// <summary>
        /// Serviço para consultar todas os mestre na API
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<MestreGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var mestreRepository = new MestreRepository();
                var mestre = mestreRepository.GetAll();


                return StatusCode(200, _mapper.Map<List<MestreGetModel>>(mestre));
            }
            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Erro ao consultar mestre: "+ e.Message});
            }

        }



        /// <summary>
        /// Serviço para consultar 1 mestre na API
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MestreGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var mestreRepository = new MestreRepository();
                var mestre = mestreRepository.GetById(id);

                if (mestre == null)
                    return StatusCode(404,new { mensagem = "Mestre não encontrada." });
                else
                    return StatusCode(200, _mapper.Map<MestreGetModel>(mestre));
            }
            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Erro ao obter categoria: "+ e.Message});
            }
        }
    }
}
