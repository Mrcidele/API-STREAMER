using System;
using Microsoft.EntityFrameworkCore;
using Streamer.Models;

namespace Streamer.Data;

public class FilmeRepository : IFilmeRepository
{
    private readonly AppDataContext _ctx;
    public FilmeRepository(AppDataContext ctx){
        _ctx=ctx;
    }
    
    public void Cadastrar(Filme filme){
        _ctx.Filmes.Add(filme);
        _ctx.SaveChanges();
    }
    public List<Filme>Listar(){
        return _ctx.Filmes.Include(x=> x.Categoria).ToList();
    }
    
    public Filme? BuscarId(int id){
        return _ctx.Filmes.FirstOrDefault(x=> x.Id ==id);
    }
    
    public void Atualizar(Filme filme){
        _ctx.Filmes.Update(filme);
        _ctx.SaveChanges();
    } 
    public void Remover(Filme filme){
        _ctx.Filmes.Remove(filme);
        _ctx.SaveChanges();
    }

}
