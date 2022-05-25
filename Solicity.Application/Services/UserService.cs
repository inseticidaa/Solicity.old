using FluentValidation;
using Solicity.Domain.DTOs.User;
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

        public async Task<IEnumerable<UserDTO>> GetAllAsync(int page, int pageSize, int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(userId);
                if (user == null) throw new Exception("This user does not exist");
                if (!user.IsAdmin) throw new UnauthorizedAccessException();

                var users = await _unitOfWork.Users.GetAllAsync(page, pageSize);
                return users.Select(x => (UserDTO)x);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Methods]
    }
}