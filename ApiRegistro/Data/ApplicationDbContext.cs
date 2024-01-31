using APIREGISTRO.Models;
using Microsoft.EntityFrameworkCore;

namespace APIREGISTRO.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
    // Defina suas entidades aqui
}