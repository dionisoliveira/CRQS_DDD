using System.Threading.Tasks;

namespace DDDSample.Domain.Interface
{
    public interface IUserRepository
    {

        User FindUser(int id);

        Task<int> Save(User user);


        Task<bool> Delete(int id);

      


    }
}
