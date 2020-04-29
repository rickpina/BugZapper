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
        [Required(ErrorMessage = "Username either is already in use or there is no Username")]
        public string Username { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
