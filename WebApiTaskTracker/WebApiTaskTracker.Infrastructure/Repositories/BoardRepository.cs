using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
    public class BoardRepository : IBoardRepository
    {
        private readonly TaskTrackerContext _taskTrackerContext;
        public BoardRepository(TaskTrackerContext taskTrackerContext)
        {
            _taskTrackerContext = taskTrackerContext;
        }

        public async Task AddBoardAsync(Domain.Models.Board board)
        {
            await _taskTrackerContext.Boards.AddAsync(board.ToEntity());
            await _taskTrackerContext.SaveChangesAsync();
        }

        public async Task<List<Domain.Models.Board>> GetBoardsAsync()
        {
            return await _taskTrackerContext.Boards.
                AsNoTracking().
                Select(s => s.ToDomain()).
                ToListAsync();
        }

        public async Task<Domain.Models.Board?> GetByIdAsync(Guid id)
        {
            var board = await _taskTrackerContext.Boards.
                AsNoTracking().
                FirstOrDefaultAsync(s => s.Id == id);
            if(board != null)
            {
                return board.ToDomain();
            }
            return null; 
        }

        public async Task RemoveBoardAsync(Guid id)
        {
            var board = await _taskTrackerContext.Boards.
                AsNoTracking().
                FirstOrDefaultAsync(s => s.Id == id);
            if(board != null)
            {
                _taskTrackerContext.Boards.Remove(board);
                await _taskTrackerContext.SaveChangesAsync();
                return;
            }
            throw new Exception(message: "Доска не найдена");
        }
    }
}
