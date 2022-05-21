﻿using Solicity.Domain.Ports;
using Solicity.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository users,
            ICardRepository cards,
            ITeamRepository teams,
            ITeamMemberRepository teamMembers)
        {
            Users = users;
            Cards = cards;
            Teams = teams;
            TeamMembers = teamMembers;
        }

        public IUserRepository Users { get; set; }
        public ICardRepository Cards { get; set; }
        public ITeamRepository Teams { get; set; }
        public ITeamMemberRepository TeamMembers { get; set; }
    }
}
