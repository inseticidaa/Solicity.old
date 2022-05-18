using Microsoft.Extensions.Configuration;
using Solicity.Domain.DTOs;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports;
using Solicity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Application.Services
{
    public class TeamService: ITeamService
    {
        #region [Props]

        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;

        public TeamService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        #endregion [Props]

        #region [Methods}

        public async Task<TeamDTO> Create(Team newTeam)
        {
            try
            {
                var count = await _unitOfWork.Teams.CountWhere(t => t.Name == newTeam.Name);

                if (count > 0)
                {
                    throw new Exception("There is already a team with that name");
                }

                await _unitOfWork.Teams.Add(newTeam);
                var team = await _unitOfWork.Teams.GetByName(newTeam.Name);

                return (TeamDTO)team;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
