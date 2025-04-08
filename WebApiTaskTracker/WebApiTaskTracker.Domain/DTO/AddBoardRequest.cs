using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Domain.DTO
{
    public class AddBoardRequest
    {
        [Required(ErrorMessage = "Имя обязательное"), MinLength(3, ErrorMessage = "Минимальная длина - 3")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid IdOwner { get; set; } = Guid.Empty;
    }
}