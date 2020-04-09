using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class MundoContext : DbContext
    {
        public MundoContext(DbContextOptions<MundoContext> options): base (options)
        {

        }

        public DbSet<Pin> Pin
        {
            get;
            set;
        }

        public DbSet<ImagemPin> ImagemPin
        {
            get;
            set;
        }
    }
}