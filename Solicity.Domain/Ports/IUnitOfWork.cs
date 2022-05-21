using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Domain.Ports
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; set; }
        ICardRepository Cards { get; set; }
        ITeamRepository Teams { get; set; }
        ITeamMemberRepository TeamMembers { get; set; }
    }
}
