using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repo.Seeds
{
    internal class UserSeed :IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Ahmet Emre",
                    LastName = "Karaca",
                    Password = "123456",
                    Email = "ahmetemre_k@hotmail.com"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Hazal",
                    LastName = "Yaşar",
                    Password = "1478963250",
                    Email = "lilhazel@gmail.com"
                }
            );
        }
    }
}
