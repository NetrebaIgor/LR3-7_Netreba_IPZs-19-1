using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class InsuranceСar
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не вказано ПІБ")]
        public string NSF { get; set; }

        [Required(ErrorMessage = "Не вказано email")]
        [EmailAddress(ErrorMessage = "Не вірно введений email")] public string Email { get; set; }

        // [RegularExpression(@"/ ^\0\d{3}\d{2}\d{2}\d{2}$/")]
        [Required(ErrorMessage = "Не вказано номер телефону")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "Не вказано місто")]

        public string City { get; set; }

        [Required(ErrorMessage = "Не вказано тип моделі")]

        public string ModelCar { get; set; }
        [Required(ErrorMessage = "Не вказано ірк випуску авто")]

        public string CarYear { get; set; }

    }
}
