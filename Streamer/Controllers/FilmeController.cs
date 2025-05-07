using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Streamer.Data;
using Streamer.Models;

namespace Streamer.Controllers;

    [Route("api/filme")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly AppDataContext _ctx;
        private readonly IFilmeRepository _repository;
        public FilmeController(AppDataContext ctx, IFilmeRepository repository){
            _ctx=ctx;
            _repository=repository;
        }

        [HttpPost("Cadastrar")]
        public IActionResult CadastrarFilme([FromBody]Filme filme){
            var filmeExistente=_ctx.Filmes.FirstOrDefault(x=>x.Nome.ToLower()== filme.Nome.ToLower());
            if(filmeExistente!=null){
                return BadRequest(new{mensagem="Filme já cadastrado"});
            }
            var categoria = _ctx.Categorias.Find(filme.CategoriaId);
           
            if(categoria==null){
                return NotFound(new{mensagem="Categoria não existe"});
            }
            filme.Categoria=categoria;
            
           _repository.Cadastrar(filme);
           return Created("",filme);
        }

        [HttpGet("Listar")]
        public IActionResult ListarFilme(){
            return Ok(_repository.Listar());
        }
        [HttpPut("Alterar")]
        public IActionResult Atualizar(int id, [FromBody]Filme FilmeAlterado){
            var Filme = _repository.BuscarId(id);
            if(Filme==null){
                return NotFound(new{mensagem="Filme Não encontrado"});
            }
            Filme.Nome=FilmeAlterado.Nome;
            Filme.Descricao=FilmeAlterado.Descricao;
            Filme.Categoria = FilmeAlterado.Categoria;
            Filme.LinkVideo=FilmeAlterado.LinkVideo;
            _ctx.SaveChanges();
            return Ok();
        }
        [HttpDelete("Deletar")]
        public IActionResult Deletar(int id){
            var filme= _repository.BuscarId(id);
            if(filme==null){
                return NotFound(new{mensagem="Filme Não encontrado"});
            }
            _repository.Remover(filme);
            return Ok();
        }

    }

