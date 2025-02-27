using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Domain
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        private readonly List<UserBoard> _userBoards = new();
        public IReadOnlyCollection<UserBoard> UserBoards => _userBoards.AsReadOnly();
    }
}
