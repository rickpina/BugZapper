using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace BugZapper.Models
{
    public class BugsModel
    {
        [BsonId]
        public Guid Id { get; set; }
        [Display(Name = "Bug ID")]
        [Range(100000, 999999, ErrorMessage ="Over six caracters used or inputing number.")]
        [Required(ErrorMessage ="You must add a Bug ID.")]
        public int BugID { get; set; }

        [Required(ErrorMessage = "You must add a Status.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "You must add Information.")]
        public string Info { get; set; }

        [Required(ErrorMessage = "You must add a Date.")]
        public string Date { get; set; }
    }
}
