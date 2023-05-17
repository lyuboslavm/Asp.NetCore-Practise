using ForumApp.Data.Configure;
using ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        //private Post FirstPost { get; set; }
        //private Post SecondPost { get; set; }
        //private Post ThirdPost { get; set; }


        public ForumAppDbContext
            (DbContextOptions<ForumAppDbContext> options)
                : base(options)
        {
        }

        public DbSet<Post> Posts { get; init; }

        //protected override OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<Post>()
        //        .HasMany(p => p.PostAnswers)
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer();

        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Post>(new PostConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
