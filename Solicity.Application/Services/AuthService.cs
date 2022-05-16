using Solicity.Domain.Entities;
using Solicity.Domain.Ports;
using Solicity.Domain.Services;

namespace Solicity.Application.Services
{
    public class AuthService : IAuthService
    {
        #region [Props]

        private IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion [Props]

        #region [Methods]

        public async Task<User> Authenticate(string email, string password)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByEmail(email);

                if (user == null) throw new Exception("User not exists");

                if (!user.CheckPassword(password)) throw new Exception("Unauthorized");

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