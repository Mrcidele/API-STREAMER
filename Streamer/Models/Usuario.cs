using Streamer.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public Permissao Permissao { get; set; } = Permissao.Usuario;
    public List<int> Favoritos { get; set; } = new List<int>();
    
    // Relacionamentos
    public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
    public List<Filme> Filmes { get; set; } = new List<Filme>();
    public List<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
}
