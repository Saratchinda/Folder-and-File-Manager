using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models;
using Microsoft.EntityFrameworkCore;

namespace EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<XFile> XFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Folder>().HasMany(f => f.XFiles).WithOne(x => x.Folder).HasForeignKey(x => x.FolderId);
        }
    }
}
