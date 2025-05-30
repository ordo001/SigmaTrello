﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Interfaces;
using WebApiTaskTracker.Domain.Interfaces.Repositories;
using WebApiTaskTracker.Domain.Interfaces.Services;
using WebApiTaskTracker.Domain.Models;
using WebApiTaskTracker.Application.Exceptions;


namespace WebApiTaskTracker.Application.Servises
{
    public class BoardServices(
        IUserBoardRepository _userBoardRepository,
        IBoardRepository _boardRepository,
        IUserRepository _userRepository) : IBoardServices
    {
        public async Task<List<Board>> GetUserBoards(Guid idUser)
        {
            try
            {
                return await _userBoardRepository.GetBoardsByUserIdAsync(idUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Board>> GetBoards()
        {
            try
            {
                return await _boardRepository.GetBoardsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Guid?> AddBoard(string name, string description, Guid idOwner)
        {
            var result = await _userRepository.GetByIdAsync(idOwner);
            if (result is null)
                throw new EntityNotFoundException<User>(idOwner);
            try
            {
                var newBoard = new Board(name, description);
                await _boardRepository.AddBoardAsync(newBoard);
                
                await _userBoardRepository.AddUserToBoardAsync(idOwner, newBoard.Id, "Admin");
                
                return newBoard.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Guid?> AddBoardWithUsers(string name, string description, Guid idOwner, List<Guid> usersId)
        {
            try
            {
                var newBoard = new Board(name, description);
                await _boardRepository.AddBoardAsync(newBoard);

                var userBoard = new List<UserBoard>
                {
                    new UserBoard(idOwner, newBoard.Id, "Admin")
                };

                userBoard.AddRange(usersId.Select(id => new UserBoard(id, newBoard.Id, "Member")));

                await _userBoardRepository.AddUserRangeToBoardAsync(newBoard.Id, userBoard);
                return newBoard.Id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task AddUserInBoard(Guid idUser, Guid idBoard, string role)
        {
            
            var user = await _userRepository.GetByIdAsync(idUser);
            if (user is null)
                throw new EntityNotFoundException<User>(idUser);

            var board = await _boardRepository.GetByIdAsync(idBoard);
            if (board is null)
                throw new EntityNotFoundException<Board>(idBoard);

            try
            {
                await _userBoardRepository.AddUserToBoardAsync(idUser, idBoard, role);
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось добавить пользователя в доску: ", ex);
            }


        }
    }
}
