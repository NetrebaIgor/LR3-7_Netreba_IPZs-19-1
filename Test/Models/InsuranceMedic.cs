using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class InsuranceMedic
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не вказано ПІБ")]

        public string NSF { get; set; }

        [Required(ErrorMessage = "Не вказано email")]
        [EmailAddress(ErrorMessage = "Не вірно введений email")]
        public string Email { get; set; }

        
       // [RegularExpression(@"/^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*/$ ", ErrorMessage = "Невірно вказаний номер телефону")]
        [Required(ErrorMessage = "Не вказаний номер телефону")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не вказано місто")]
        public string City { get; set; }
        [Required]
        public string Clinic { get; set; }
    }
}
