using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Domain.Models
{
    public class UserBoard
    {
        public Guid IdUser { get; set; }
        public Guid IdBoard { get; set; }
        public string Role { get; set; } = string.Empty;

        public UserBoard(Guid idUser, Guid idBoard, string role)
        {
            IdUser = idUser;
            IdBoard = idBoard;
            Role = role;
        }
    }
}
