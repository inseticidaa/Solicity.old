using FluentValidation;
using Solicity.Domain.DTOs;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports;
using Solicity.Domain.Services;
using Solicity.Domain.Validators;

namespace Solicity.Application.Services
{
    public class UserService : IUserService
    {
        #region [Props]

        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        #endregion [Props]

        #region [Methods]

        #endregion [Methods]
    }
}