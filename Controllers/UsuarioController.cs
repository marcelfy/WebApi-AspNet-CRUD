using Microsoft.AspNetCore.Mvc;
using Teste.Models;
using Teste.Repository.Interfaces;

namespace Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : MainController
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try
            {
                List<Usuario> usuarios = await _usuarioRepository.BuscarTodos();
                return CustomResponse(usuarios);
            }
            catch (Exception ex)
            {
                return NotificarErro(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            try
            {
                Usuario usuario = await _usuarioRepository.BuscarPorID(id);
                return CustomResponse(usuario);
            }
            catch (Exception ex)
            {
                return NotificarErro(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(Usuario usuario)
        {
            try
            {
                await _usuarioRepository.Adicionar(usuario);
                return CustomResponse("Usuario cadastrado com suceso");
            }
            catch(Exception ex)
            {
                return NotificarErro(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(Usuario usuario, int id)
        {
            try
            {
                await _usuarioRepository.Atualizar(usuario, id);
                return CustomResponse("Usuario atualizado com sucesso");
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
                await _usuarioRepository.Excluir(id);
                return CustomResponse("Usuario excluido com sucesso");
            }
            catch(Exception ex)
            {
                return NotificarErro(ex.Message);
            }
        }
    }
}