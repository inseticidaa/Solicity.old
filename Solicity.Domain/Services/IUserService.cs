﻿using Solicity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Domain.Services
{
    public interface IUserService
    {
        Task<User> Create(User newUser);
    }
}
