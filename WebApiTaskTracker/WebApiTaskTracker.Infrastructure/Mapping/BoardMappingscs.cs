using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApiTaskTracker.Domain.Models;
using WebApiTaskTracker.Infrastructure.Data;

namespace WebApiTaskTracker.Infrastructure.Mapping
{
    /// <summary>
    /// Маппер сущностей Board
    /// </summary>
    public static class BoardMappingscs
    {
        public static Domain.Models.Board ToDomain(this Data.Board board)
        {
            return new Domain.Models.Board(board.Id,board.Name, board.Description, board.UserBoards.Select(s => s.ToDomain()).ToList());
        }

        public static Data.Board ToEntity(this Domain.Models.Board board)
        {
            return new Data.Board
            {
                Id = board.Id,
                Name = board.Name,
                Description = board.Description,
                UserBoards = board.UserBoards.Select(s => s.ToEntity()).ToList()
            };
        }
    }
}
