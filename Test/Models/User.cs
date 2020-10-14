using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class User
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Не вказано пошту")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Не вказано пароль")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Не вказано ім'я")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Не вказано прізвище")]

        public string Surname { get; set; }
        [Required(ErrorMessage = "Не вказано ім'я по батькові")]

        public string Petronymic { get; set; }
        [Required(ErrorMessage = "Не вказано номер телефону")]

        public string Phone { get; set; }

         
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
