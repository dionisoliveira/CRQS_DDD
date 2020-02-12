using DDDSample.Application.Model;

namespace DDDSample.Application.Interface.User
{
    public interface IUserAppService
    {
        UserViewModel FindUser(int id);

        void SaveUser(UserViewModel usuario);

        void DeleteUser(int id);

      
    }
}
