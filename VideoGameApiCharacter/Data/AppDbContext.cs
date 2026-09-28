using Microsoft.EntityFrameworkCore;
using VideoGameApiCharacter.Models;

namespace VideoGameApiCharacter.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Character> Characters => Set<Character>();
    }
}
