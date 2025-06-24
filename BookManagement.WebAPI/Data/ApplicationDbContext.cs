using BookManagement.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UsersBook { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<BlacklistedToken> blacklistedTokens { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
