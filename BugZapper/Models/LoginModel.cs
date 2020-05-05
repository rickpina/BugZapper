using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [StringLength(60, MinimumLength = 4, ErrorMessage = "Password must be at least 4 characters long.")]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
