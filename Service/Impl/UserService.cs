using Domain;
using Infrastructure.Dapper;

namespace Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IDapperRepository<User> _userRepository;
        public UserService(IDapperRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public long Add(User user)
        {
            return _userRepository.Insert(user);
        }
    }
}
