using BookstoreServerApiDotnetCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookstoreServerApiDotnetCore.Data
{
    //public class BookstoreContext : DbContext
    public class BookstoreContext : IdentityDbContext<AppUser>
    {
        public BookstoreContext( DbContextOptions<BookstoreContext> options ) : base(options) 
        { 
        }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
/*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=WorkShopRealAPIPublic;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
*/
    }
}
