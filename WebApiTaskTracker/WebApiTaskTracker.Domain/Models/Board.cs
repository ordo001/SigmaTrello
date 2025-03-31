using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Models
{
    public class Board
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        private List<UserBoard> _userBoard;
        public ICollection<UserBoard> UserBoards => _userBoard;

        public Board(Guid id, string name, string description, List<UserBoard>? userBoards = null)
        {
            Id = id;
            Name = name;
            Description = description;
            _userBoard = userBoards ?? new();
        }

        public Board(string name, string description, List<UserBoard>? userBoards = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            _userBoard = userBoards ?? new();
        }

        //public void AddUser(User user, string role)
        //{
        //    if (_users.Any(u => u.Id == user.Id))
        //        throw new InvalidOperationException("Пользователь уже добавлен в эту доску");

        //    _users.Add(user);
        //}
    }
}
