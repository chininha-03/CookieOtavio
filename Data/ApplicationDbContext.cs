using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LocadoraMVC.Models;

namespace CookieOtavio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LocadoraMVC.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<LocadoraMVC.Models.Cookie> Cookie { get; set; } = default!;
        public DbSet<LocadoraMVC.Models.Estoque> Estoque { get; set; } = default!;
        public DbSet<LocadoraMVC.Models.ItemVenda> ItemVenda { get; set; } = default!;
        public DbSet<LocadoraMVC.Models.TipoCookie> TipoCookie { get; set; } = default!;
    }
}
