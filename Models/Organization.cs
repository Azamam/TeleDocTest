using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeleDocTest.Models
{
    public class Organization
    {
        [Display(Name = "ID")]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^[\d+]{10,12}$", ErrorMessage = "Неккоректный ИНН")]
        [Display(Name = "ИНН")]
        public string Inn { get; set; }

        [Display(Name = "Список учредителей")]
        public virtual ICollection<FounderItem> Founders { get; set; }
    }
}