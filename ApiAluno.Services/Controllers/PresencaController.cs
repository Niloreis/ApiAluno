using ApiAluno.Services.Models;
using ApiMestre.Data.Entities;
using ApiMestre.Data.Repositories;
using ApiPresenca.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private readonly IMapper _mapper;

        //construtor para inicializar os atributos da classe
        public PresencaController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Post(PresencaPostModels model)
        {
            try
            {
                var presencas = _mapper.Map<Presenca>(model);

                var presencaRepository = new PresencaRepository();
                presencaRepository.Add(presencas);

                //HTTP 201 (CREATED)
                return StatusCode(201, new
                {
                    mensagem = "presenca cadastrado com sucesso.",

                    presenca = _mapper.Map<PresencaGetModel>(presencas)

                });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = "Falha ao cadastrar a presenca: " + e.Message });
            }
        }
        [HttpPut]
        public IActionResult Put(PresencaPutModel model)
        {
            try
            {
                var presencaRepository = new PresencaRepository();

                if (presencaRepository.GetById(model.IdPresenca) == null)
                    return StatusCode(404, new { mensagem = "Presenca não encontrado." });

                var Presenca = _mapper.Map<Presenca>(model);
                presencaRepository.Update(Presenca);

                //HTTP 200 (OK)
                return StatusCode(200, new
                {
                    mensagem = "Presenca atualizada com sucesso.",
                    mestre = _mapper.Map<PresencaGetModel>(Presenca)
                });
            }



            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao atualizar aluno: " + e.Message });
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<PresencaGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var presencaRepository = new PresencaRepository();
                var presenca = presencaRepository.GetAll();


                return StatusCode(200, _mapper.Map<List<PresencaGetModel>>(presenca));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Erro ao consultar aluno : " + e.Message });
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PresencaGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var presencaRepository = new PresencaRepository();
                var presenca = presencaRepository.GetById(id);

                if (presenca == null)
                    return StatusCode(404, new { mensagem = "Aluno não encontrada." });
                else
                    return StatusCode(200, _mapper.Map<PresencaGetModel>(presenca));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Erro ao obter categoria: " + e.Message });
            }
        }

    }
}



