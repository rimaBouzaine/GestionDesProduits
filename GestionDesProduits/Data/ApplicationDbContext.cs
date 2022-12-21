using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using GestionDesProduits.Models;
=======
>>>>>>> e0ddb59534431cdb5a754c898f9f99707dce0b8d

namespace GestionDesProduits.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
<<<<<<< HEAD
        public DbSet<GestionDesProduits.Models.Magasin> Magasin { get; set; }
=======
>>>>>>> e0ddb59534431cdb5a754c898f9f99707dce0b8d
    }
}