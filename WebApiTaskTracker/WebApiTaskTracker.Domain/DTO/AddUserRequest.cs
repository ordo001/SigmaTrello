using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
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
        [Required(ErrorMessage = "Логин обязателен"),
         MinLength(3, ErrorMessage = "Минимальная длина логина - 3 символа")]
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Свойство отвечает за хранение пароля пользователя.
        /// </summary>
        /// <remarks>
        /// Должно содержать строку, представляющую пароль пользователя.
        /// Используется при создании нового пользователя через API.
        /// Требуется для передачи в соответствующий метод сервиса пользователей.
        /// </remarks>
        /// [Required(ErrorMessage = "Логин обязателен"),
        [Required(ErrorMessage = "Пароль обязателен"),
         MinLength(3, ErrorMessage = "Минимальная длина Пароль - 6 символов"),
        RegularExpression("^(?=.*[!@#$%^&*(),.?\":{}|<>])(?=.*[A-Z])(?=.*\\d).+$", 
            ErrorMessage = "Пароль не соответствует требованиям содержания")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Свойство, представляющее email пользователя.
        /// Используется для задания электронной почты в запросах добавления нового пользователя.
        /// </summary>
        [Required(ErrorMessage = "Почта обязательна"),
        EmailAddress(ErrorMessage = "Некорректный формат почты")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Свойство для хранения имени пользователя.
        /// Используется при добавлении нового пользователя в систему.
        /// Значение должно быть предоставлено клиентом.
        /// </summary>
        [Required(ErrorMessage = "Имя обязательно")]
        public string Username { get; set; } = string.Empty;
    }
}
