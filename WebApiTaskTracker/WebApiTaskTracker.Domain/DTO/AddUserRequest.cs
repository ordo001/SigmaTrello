using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Domain.DTO
{
    /// <summary>
    /// Класс AddUserRequest используется для представления данных, необходимых для создания нового пользователя.
    /// </summary>
    public class AddUserRequest
    {
        /// <summary>
        /// Свойство представляет собой логин пользователя.
        /// </summary>
        /// <remarks>
        /// Логин необходим для идентификации пользователя в системе.
        /// Значение должно быть уникальным и соответствовать установленным требованиям
        /// к формату при создании нового пользователя.
        /// </remarks>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Свойство отвечает за хранение пароля пользователя.
        /// </summary>
        /// <remarks>
        /// Должно содержать строку, представляющую пароль пользователя.
        /// Используется при создании нового пользователя через API.
        /// Требуется для передачи в соответствующий метод сервиса пользователей.
        /// </remarks>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Свойство, представляющее email пользователя.
        /// Используется для задания электронной почты в запросах добавления нового пользователя.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Свойство для хранения имени пользователя.
        /// Используется при добавлении нового пользователя в систему.
        /// Значение должно быть предоставлено клиентом.
        /// </summary>
        public string Username { get; set; } = string.Empty;
    }
}
