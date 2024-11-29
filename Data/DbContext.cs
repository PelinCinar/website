using Microsoft.EntityFrameworkCore;

namespace website.Data
{
    public class DataContext : DbContext //dbcontexten kalıtım alcağız ki sorunsuz çalışalım tnaımlaman lazım yoksa gg.
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) //benim dbcontextim data context oldu dedidk
        {

        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Blog> Blogs => Set<Blog>();

    }
}