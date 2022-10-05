using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CommandModel
    {
        public int Id { get; set; }
        public string Platform { get; set; }
        public string CommandDesc { get; set; }
        public string Command { get; set; }
    }
}
