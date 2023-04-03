using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorio.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usurario =await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usurario);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usurario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usurario);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar([FromBody] int id)
        {
            
            bool apagado = await _usuarioRepositorio.Apagar( id);
            return Ok(apagado);
        }

    }
}
