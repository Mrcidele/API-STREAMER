using System;

namespace Streamer.Models;

public class Assinatura
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public bool Ativa { get; set; }
}
