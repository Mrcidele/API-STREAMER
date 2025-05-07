using System;

namespace Streamer.Models;

public class Filme
{
    public int Id { get; set; }
    public string Nome{get;set;}
    public string Descricao{get;set;}
    public Categoria? Categoria{get;set;}
    public int CategoriaId{get;set;}
    public string LinkVideo{get;set;}


}
