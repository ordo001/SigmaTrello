using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Infrastructure.Data
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int IdBoard { get; set; }
        public Board Board {  get; set; }
        public List<Card> Cards { get; set; } = new ();
    }
}
