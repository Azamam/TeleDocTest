using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleDocTest.Models
{
    public class Founder
    {
        [Display(Name = "ID")]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [NotMapped]
        public string FullInfo
        {
            get
            {
                return string.Format("{0} {1} {2} [ID: {3}]", LastName, FirstName, MiddleName, Id);
            }
        }
    }
}