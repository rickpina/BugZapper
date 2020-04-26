using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace BugZapper.Models
{
    public class LoginModel
    {
        [BsonId]
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Email { get; set; }

    }
}
