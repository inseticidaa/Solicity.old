using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        int Id { get; set; }

        [Required]
        DateTime CreatedAt { get; set; }
        [Required]
        DateTime UdpatedAt { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
