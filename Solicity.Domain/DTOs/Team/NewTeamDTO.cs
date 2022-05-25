﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Solicity.Domain.DTOs.Team
{
    public class NewTeamDTO
    {
        public string? Description { get; set; }
        public string Name { get; set; }
        public bool Public{ get; set; }
    }
}