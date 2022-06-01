using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Domain.DTOs
{
    public class RequestTypeDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Enabled { get; set; }
    }
}
