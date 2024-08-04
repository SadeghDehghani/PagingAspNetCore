using Microsoft.EntityFrameworkCore;

namespace PagingAspNet.Models.Domain
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }
        public virtual DbSet<Post> Posts { get; set; }
    }
}
