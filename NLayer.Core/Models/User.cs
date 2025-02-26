﻿using NLayer.Core.DTO;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace NLayer.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string JwtToken { get; set; }
        public virtual ICollection<Todo> Todos { get; set; }
        

    }
}
