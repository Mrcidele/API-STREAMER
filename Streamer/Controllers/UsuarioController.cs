using Microsoft.AspNetCore.Mvc;
using Streamer.Data;
using Streamer.Models;

namespace Streamer.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDataContext _ctx;
        private readonly IUsuarioRepository _repository;

        public UsuarioController(AppDataContext ctx, IUsuarioRepository repository)
        {
            _ctx = ctx;
            _repository = repository;
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _repository.Cadastrar(usuario);
            return Created("", usuario);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_repository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            var usuario = _repository.BuscarId(id);
            if (usuario == null)
            {
                return NotFound(new { mensagem = "Usuário não encontrado" });
            }
            return Ok(usuario);
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Atualizar(int id, [FromBody] Usuario usuarioAlterado)
        {
            var usuario = _repository.BuscarId(id);
            if (usuario == null)
            {
                return NotFound(new { mensagem = "Usuário não encontrado" });
            }
            usuario.Nome = usuarioAlterado.Nome;
            usuario.Email = usuarioAlterado.Email;
            usuario.Senha = usuarioAlterado.Senha;
            usuario.Permissao = usuarioAlterado.Permissao;
            usuario.Favoritos = usuarioAlterado.Favoritos;

            _repository.Atualizar(usuario);
            return Ok();
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var usuario = _repository.BuscarId(id);
            if (usuario == null)
            {
                return NotFound(new { mensagem = "Usuário não encontrado" });
            }
            _repository.Remover(usuario);
            return Ok();
        }
    }
}