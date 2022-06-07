using Microsoft.EntityFrameworkCore;
using Online.Will.API.Models;

namespace Online.Will.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<Estate> Estates { get; set; }
    }
}
