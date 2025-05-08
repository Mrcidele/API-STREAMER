public class Assinatura
{
    public int Id { get; set; }
    public int UsuarioId { get; set; } // Relacionamento com Usuario
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public bool Ativa { get; set; }
    
    // Navegação
    public required Usuario Usuario { get; set; }
}
