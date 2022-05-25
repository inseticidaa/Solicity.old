using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Domain.Entities
{
    public class RequestType: BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Enabled { get; set; }
    }
}
