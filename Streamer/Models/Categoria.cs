using System;

namespace Streamer.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Filme>? Filmes{get;set;}
}
