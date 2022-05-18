using Solicity.Domain.Entities;
using Solicity.Domain.Ports;
using Solicity.Domain.Services;

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

        public async Task<User> Create(User newUser)
        {
            try
            {
                var count = await _unitOfWork.Users.CountWhere(u => u.Email == newUser.Email);

                if (count > 0)
                {
                    throw new Exception("User already registered");
                }

                await _unitOfWork.Users.Add(newUser);
                var user = await _unitOfWork.Users.GetByEmail(newUser.Email);

                if (user == null) return null;

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Methods]
    }
}