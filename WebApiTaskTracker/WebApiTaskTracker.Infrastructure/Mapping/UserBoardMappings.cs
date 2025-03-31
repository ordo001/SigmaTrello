using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Infrastructure.Mapping
{
    public static class UserBoardMappings
    {
        public static UserBoard ToDomain(this Data.UserBoard userBoard)
        {
            return new UserBoard(userBoard.IdUser, userBoard.IdBoard, userBoard.Role);
        }

        public static Data.UserBoard ToEntity(this UserBoard userBoard)
        {
            return new Data.UserBoard
            {
                IdUser = userBoard.IdUser,
                IdBoard = userBoard.IdBoard,
                Role = userBoard.Role
            };
        }
    }
}
