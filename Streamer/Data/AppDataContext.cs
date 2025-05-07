using System;
using Microsoft.EntityFrameworkCore;
using Streamer.Models;

namespace Streamer.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options){}

    public DbSet<Filme> Filmes{get;set;}
    public DbSet<Usuario> Usuarios{get;set;}
    public DbSet<Comentario> Comentarios { get; set; }
    public DbSet<Assinatura> Assinaturas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}
