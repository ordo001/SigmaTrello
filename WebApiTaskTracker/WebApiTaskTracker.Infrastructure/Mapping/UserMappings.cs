using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Infrastructure.Mapping
{
    public static class UserMappings
    {
        public static User ToDomain(this Data.User user)
        {
            return new User(
                user.Login,
                user.UserName,
                user.PasswordHash,
                user.Email,
                user.UserBoards?.Select(u => u.ToDomain()).ToList() ?? new List<UserBoard>()
                );
        }

        public static Data.User ToEntity(this User user)
        {
            return new Data.User
            {
                Id = user.Id,
                Login = user.Login,
                PasswordHash = user.PasswordHash,
                UserName = user.UserName,
                Email = user.Email,
                UserBoards = user.UserBoards?.Select(u => u.ToEntity()).ToList() ?? new List<Data.UserBoard>()
            };
        }
    }
}
