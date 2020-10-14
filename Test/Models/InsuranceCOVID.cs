using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class InsuranceCOVID
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не вказано піб")]
        public string NSF { get; set; }

        public DateTime Date { get; set; }


    }
}
