using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Domain.DTO
{
    public class AddUserInBoardRequest
    {
        public Guid IdUser { get; set; }
        public Guid IdBoard { get; set; }
        public string? Role { get; set; } = string.Empty;

        public AddUserInBoardRequest(Guid IdUser, Guid IdBoard, string Role)
        {
            this.IdUser = IdUser;
            this.IdBoard = IdBoard;
            this.Role = Role.Any() ? Role : "Member";
        }
    }
}
