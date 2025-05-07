using System;
using Streamer.Models;

namespace Streamer.Data;

public interface IFilmeRepository
{

    public void Cadastrar(Filme filme);
    public List<Filme>Listar();
    public void Atualizar(Filme filme);
    public Filme BuscarId(int id);
    public void Remover(Filme filme);
}
