using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class InsuranceAutoCitizen
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Не вказано ПІБ")]
        public string NSF { get; set; }
        [Required(ErrorMessage = "Не вказано тип двигуна")]

        public string Engine { get; set; }
        [Required(ErrorMessage = "Не вказано дату")]

        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Не вказано місто")]

        public string City { get; set; }
        [Required(ErrorMessage = "Не вказано франшиза чи ні")]

        public string Franchise { get; set; }


        public string RoadAccident { get; set; }
    }
}
