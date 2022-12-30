using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repo.Seeds
{
    internal class TodoSeed:IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasData(new Todo
            {
                Id = 1,
                UserId = 1,
                Title = "Finish Project",
                Description = "Finish the TODO App Until Next Tuesday",
                Status="In Progress",
                IsDeleted = true,
                CreatedDate = DateTime.Now,
            },
            new Todo
            {
                Id = 2,
                UserId = 1,
                Title = "Make A Coffee",
                Description = "You Need Some Cafein My Man",
                Status ="Active",
                IsDeleted = false,
                CreatedDate = DateTime.Now,

            },
            new Todo
            {
                Id = 3,
                UserId = 2,
                Title = "Buy Make-Up Product",
                Description = "I Need A New Eyeliner",
                Status = "Done",
                IsDeleted = false,
                CreatedDate = DateTime.Now,

            });
        }
    }
}
