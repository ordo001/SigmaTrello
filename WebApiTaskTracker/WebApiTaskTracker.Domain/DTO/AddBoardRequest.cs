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


        public List<ValidationResult?> Validation(AddBoardRequest addBoardRequest)
        {
            var context = new ValidationContext(addBoardRequest);
            var result = new List<ValidationResult>();
            if (!Validator.TryValidateObject(addBoardRequest, context, result, true))
            {
                return result!;
            }

            return result!;
        }
        
        public List<ValidationResult?> Validation2<T>(T validationEntity)
        {
            var context = new ValidationContext(validationEntity);
            var result = new List<ValidationResult>();
            if (!Validator.TryValidateObject(validationEntity, context, result, true))
            {
                return result!;
            }

            return result!;
        }
    }
}