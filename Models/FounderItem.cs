using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleDocTest.Models
{
    public class FounderItem
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        [Display(Name = "Учредитель")]
        public long FounderId { get; set; }
        public virtual Founder Founder { get; set; }
        [NotMapped]
        public List<long> FounderIds { get; set; }
    }
}