using System;
using Microsoft.AspNetCore.Mvc;
using Streamer.Models;

namespace Streamer.Data;

public interface ICategoriaRepository
{   
    public void CadastrarCate(Categoria categoria);
    public void AtualizarCate(Categoria categoria);
    public Categoria BuscarCategoria(int id);
    public List<Categoria> ListarCate();

}
