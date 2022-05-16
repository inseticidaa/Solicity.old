using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence.EFCore.Repositories
{
    public class CardRepository: EfRepository<Card>, ICardRepository
    {
        public CardRepository(PersistenceContext context) : base(context)
        {
        }
    }
}
