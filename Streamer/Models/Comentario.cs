using System;

namespace Streamer.Models;

public class Comentario
{
     public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int FilmeId { get; set; }
    public string Texto { get; set; }
    public DateTime DataComentario { get; set; }

}
