using Microsoft.AspNetCore.Mvc;
using Teste.Models;
using Teste.Repository.Interfaces;

namespace Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : MainController
    {

        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> Get()
        {
            try
            {
                List<Tarefa> usuarios = await _tarefaRepository.BuscarTodos();
                return CustomResponse(usuarios);
            }
            catch (Exception ex)
            {
                return NotificarErro(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Tarefa>> GetById(int id)
        {
            try
            {
                Tarefa tarefa = await _tarefaRepository.BuscarPorID(id);
                return CustomResponse(tarefa);
            }
            catch (Exception ex)
            {
                return NotificarErro(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(Tarefa usuario)
        {
            try
            {
                await _tarefaRepository.Adicionar(usuario);
                return CustomResponse("Tarefa cadastrada com suceso!");
            }
            catch(Exception ex)
            {
                return NotificarErro(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(Tarefa usuario, int id)
        {
            try
            {
                await _tarefaRepository.Atualizar(usuario, id);
                return CustomResponse("Tarefa atualizada com sucesso");
            }
            catch(Exception ex)
            {
                return NotificarErro(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _tarefaRepository.Excluir(id);
                return CustomResponse("Tarefa excluida com sucesso");
            }
            catch(Exception ex)
            {
                return NotificarErro(ex.Message);
            }
        }
    }
}