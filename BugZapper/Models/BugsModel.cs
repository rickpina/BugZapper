using System;
using System.Collections.Generic;
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
        public int BugID { get; set; }
        public string Status { get; set; }
        public string Info { get; set; }
        public string Date { get; set; }
    }
}
