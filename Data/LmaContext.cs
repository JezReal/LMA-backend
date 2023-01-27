using LMA_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LMA_backend.Data;

public class LmaContext : DbContext
{
    public LmaContext(DbContextOptions<LmaContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Credential> Credentials { get; set; } = null!;
}