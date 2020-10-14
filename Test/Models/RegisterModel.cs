using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не вказаний Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не вказано ім'я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не вказано прізвище")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не вказано ім'я по батькові")]
        public string Petronymic { get; set; }
        [Required(ErrorMessage = "Не вказаний телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введено невірно")]
        public string ConfirmPassword { get; set; }
    }
}
