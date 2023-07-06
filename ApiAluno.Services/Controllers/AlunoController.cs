using ApiAluno.Services.Models;
using ApiMestre.Data.Entities;
using ApiMestre.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ApiMestre.Data.Repositories.AlunoRepository;

namespace ApiAluno.Services.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IMapper _mapper;

        //construtor para inicializar os atributos da classe
        public AlunoController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Serviço para cadastro de alunos na API
        /// </summary>
        [HttpPost]
        public IActionResult Post(AlunoPostModel model)
        {
            try
            {
                var aluno = _mapper.Map<Alunos>(model);

                var alunoRepository = new AlunoRepository();
                alunoRepository.Add(aluno);

                //HTTP 201 (CREATED)
                return StatusCode(201, new
                {
                    mensagem = "aluno cadastrado com sucesso.",

                    categoria = _mapper.Map<AlunoGetModel>(aluno)

                });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = "Falha ao cadastrar o aluno: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para edição de alunos na API
        /// </summary>
        [HttpPut]
        public IActionResult Put(AlunoPutModel model)
        {
            try
            {
                var alunoRepository = new AlunoRepository();

                if (alunoRepository.GetById(model.IdAluno) == null)
                    return StatusCode(404, new { mensagem = "Aluno não encontrado." });

                var aluno = _mapper.Map<Alunos>(model);
                alunoRepository.Update(aluno);

                //HTTP 200 (OK)
                return StatusCode(200, new
                {
                    mensagem = "Aluno atualizada com sucesso.",
                    mestre = _mapper.Map<AlunoGetModel>(aluno)
                });
            }



            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao atualizar aluno: " + e.Message });
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
                var alunoRepository = new AlunoRepository();
                var aluno = alunoRepository.GetById(id);

                if (aluno == null)
                    return StatusCode(404, new { mensagem = "Aluno não encontrado." });

                alunoRepository.Delete(aluno);

                //HTTP 200 (OK)
                return StatusCode(200, new
                {
                    mensagem = "Aluno excluída com sucesso.",
                    aluno = _mapper.Map<AlunoGetModel>(aluno)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao excluir aluno: " + e.Message });
            }
        }



        /// <summary>
        /// Serviço para consultar todas os alunos na API
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<AlunoGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var alunoRepository = new AlunoRepository();
                var aluno = alunoRepository.GetAll();


                return StatusCode(200, _mapper.Map<List<AlunoGetModel>>(aluno));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Erro ao consultar aluno : " + e.Message });
            }
        }



        /// <summary>
        /// Serviço para consultar 1 aluno na API
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AlunoGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var alunoRepository = new AlunoRepository();
                var aluno = alunoRepository.GetById(id);

                if (aluno == null)
                    return StatusCode(404, new { mensagem = "Aluno não encontrada." });
                else
                    return StatusCode(200, _mapper.Map<AlunoGetModel>(aluno));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Erro ao obter categoria: " + e.Message });
            }
        }

    }
} 
