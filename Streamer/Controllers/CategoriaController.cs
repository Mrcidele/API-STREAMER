using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Streamer.Data;
using Streamer.Models;

namespace Streamer.Controllers;

    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDataContext _ctx;
        private readonly ICategoriaRepository _repository;
        public CategoriaController(AppDataContext ctx,ICategoriaRepository repository){
            _ctx=ctx;
            _repository=repository;
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody]Categoria categoria){
           var categoriaExistente= _ctx.Categorias.FirstOrDefault(x=>x.Nome.ToLower()==categoria.Nome.ToLower());
           if(categoriaExistente!=null){
            return NotFound(new{mensagem="Categoria já foi cadastrada"});
           }
            _repository.CadastrarCate(categoria);
            return Created("", categoria);
        }

        [HttpPut("atualizar")]
        public IActionResult Update(int id, [FromBody] Categoria categoriaAlterada){
            var categoria = _repository.BuscarCategoria(id);
            if(categoria==null){
                return NotFound(new{mensagem="A categoria não foi encontrada "});
            }
            categoria.Nome=categoriaAlterada.Nome;
            _ctx.SaveChanges();
            return Ok();
        }
        [HttpGet("listar")]
        public IActionResult Listar(){
            return Ok(_repository.ListarCate());
        }




    }

