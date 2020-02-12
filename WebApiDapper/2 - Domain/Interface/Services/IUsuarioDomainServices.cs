using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.Domain.Interface.Services
{
    public interface IUserDomainServices
    {
        User FindUser(int id);

        Task<int> Save(User user);
    }
}
