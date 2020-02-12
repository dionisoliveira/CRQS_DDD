using System.Threading.Tasks;
using DDDSample.Domain.Interface;
using DDDSample.Domain.Interface.Services;

namespace DDDSample.Domain.Services
{
    public class UserDomainServices : IUserDomainServices
    {
        IUserRepository _userRepository;
      

        public UserDomainServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
       
        }

        public User FindUser(int id)
        {
    
            return _userRepository.FindUser(id);
        }

        public async Task<int> Save(User usuario)
        {


            return await _userRepository.Save(usuario);

        }
    }
}
