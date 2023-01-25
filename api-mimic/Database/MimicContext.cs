using api_mimic.Models;
using Microsoft.EntityFrameworkCore;
namespace api_mimic.Database
{
    public class MimicContext : DbContext
    {
        public MimicContext(DbContextOptions<MimicContext> options) : base(options)
        {
        }
        public DbSet<Word> Words { get; set; }
    }
}
