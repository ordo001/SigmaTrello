using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Interfaces.Repositories;
using WebApiTaskTracker.Domain.Models;
using WebApiTaskTracker.Infrastructure.Data;
using WebApiTaskTracker.Infrastructure.Mapping;

namespace WebApiTaskTracker.Infrastructure.Repositories
{
    public class UserBoardRepository : IUserBoardRepository
    {
        private readonly TaskTrackerContext _taskTrackerContext;
        public UserBoardRepository(TaskTrackerContext taskTrackerContext)
        {
            _taskTrackerContext = taskTrackerContext;
        }
        public async Task AddUserToBoardAsync(Guid userId, Guid boardId, string role)
        {
            var newUserToBoard = new Data.UserBoard
            {
                IdUser = userId,
                IdBoard = boardId,
                Role = role
            };
            await _taskTrackerContext.UserBoards.AddAsync(newUserToBoard);
            await _taskTrackerContext.SaveChangesAsync();
        }

        public async Task AddUserRangeToBoardAsync(Guid boardId, List<Domain.Models.UserBoard> userBoard)
        {
            await _taskTrackerContext.UserBoards.AddRangeAsync(userBoard.Select(ub => ub.ToEntity()));
            await _taskTrackerContext.SaveChangesAsync();
        }

        public async Task<List<Domain.Models.Board>> GetBoardsByUserIdAsync(Guid userId)
        {
            var boardsList = await _taskTrackerContext.UserBoards.
                AsNoTracking().
                Where(u => u.IdUser == userId).
                Select(s => s.Board.ToDomain()).
                ToListAsync();

            return boardsList;
        }

        public async Task<List<Domain.Models.User>> GetUsersByBoardIdAsync(Guid boardId)
        {
            var userList = await _taskTrackerContext.UserBoards.
                AsNoTracking().
                Where(s => s.IdBoard == boardId).
                Select(s => s.User.ToDomain()).
                ToListAsync();

            return userList;
        }

        public async Task RemoveUserFromBoardAsync(Guid userId, Guid boardId)
        {
            // Метод не должне заботиться о наличии юзеров в бд, перенести ответственность выше
            var userToDemove = await _taskTrackerContext.UserBoards.
                AsNoTracking().
                FirstOrDefaultAsync(s => s.IdUser == userId && s.IdBoard == boardId);
            if (userToDemove != null)
            {
                _taskTrackerContext.UserBoards.Remove(userToDemove);
                await _taskTrackerContext.SaveChangesAsync();
            }
            else
                throw new Exception(message: "Пользователь не найден");
        }

        public async Task UpdateUserRoleAsync(Guid userId, Guid boardId, string newRole)
        {
            // Метод не должне заботиться о наличии юзеров в бд, перенести ответственность выше
            var userForUpdate = await _taskTrackerContext.UserBoards.
                AsNoTracking().
                FirstOrDefaultAsync(s => s.IdBoard == boardId && s.IdUser == userId);
            if (userForUpdate != null)
            {
                userForUpdate.Role = newRole;
                await _taskTrackerContext.SaveChangesAsync();
            }
            else
                throw new Exception(message: "Пользователь не найден");
        }
    }
}
