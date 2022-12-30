using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repo.Configurations
{
    internal class TodoConfiguration:IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.Status).IsRequired();
            builder.HasOne(x=>x.User).WithMany(x=>x.Todos).HasForeignKey(x=>x.UserId);
            builder.ToTable("Todos");
        }
    }
}
