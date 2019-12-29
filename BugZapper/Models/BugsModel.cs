using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugZapper.Models
{
    public class BugsModel
    {
        public int BugID { get; set; }
        public string Status { get; set; }
        public string Info { get; set; }
        public string Date { get; set; }
    }
}
