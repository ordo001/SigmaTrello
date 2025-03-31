using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Infrastructure.Data
{
    public class Section
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Position { get; set; }
        public Guid IdBoard { get; set; }
        public Board Board {  get; set; }
        public List<Card> Cards { get; set; } = new ();
    }
}
