using Streamer.Models;

public class Comentario
{
    public int Id { get; set; }
    public int UsuarioId { get; set; } // Relacionamento com Usuario
    public int FilmeId { get; set; }
    public string Texto { get; set; }
    public DateTime DataComentario { get; set; }
    
    // Navegação
    public Usuario Usuario { get; set; }
    public Filme Filme { get; set; }
}