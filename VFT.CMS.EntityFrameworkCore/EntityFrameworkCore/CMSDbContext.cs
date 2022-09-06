using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VFT.CMS.Entities;

namespace VFT.CMS.EntityFrameworkCore
{
    public class CMSDbContext : IdentityDbContext<CMSIdentityUser>
    {
        public CMSDbContext()
        {
        }

        public CMSDbContext(DbContextOptions options)
         : base(options)
        {
        }

       // public CMSDbContext(DbContextOptions<CMSIdentityUser> options)
       //: base(options)
       // {
       // }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Menu
            builder.Entity<Menu>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.HasIndex(p => p.Title);
            });

            //Category: danh muc
            builder.Entity<Category>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.HasIndex(p => p.Title);
            });

            //Bài viết posts
            builder.Entity<Posts>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.HasIndex(p => p.Title);
            });

            //Photo
            builder.Entity<Photo>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.HasIndex(p => p.Description);
            });

            //Meta
            builder.Entity<Meta>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.HasIndex(p => p.MetaKey);
            });

            //VisitCount
            builder.Entity<VisitCount>(entity =>
            {
                entity.HasKey(t => t.Id);
            });
        }
    }
}
