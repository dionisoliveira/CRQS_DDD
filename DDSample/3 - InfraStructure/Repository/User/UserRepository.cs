using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;
using DDDSample.Domain.Interface;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace DDDSample.InfraStructure.Repository.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public static List<Domain.User> mockDataBase = new List<Domain.User>();


        public UserRepository([FromServices] IConfiguration config) : base(config, "NAME_CONNECTION_STRING")
        {
        }

        public async Task<int> Save(Domain.User user)
        {
            user.Id = 123;
             mockDataBase.Add(user);

            return 123;//Return new guid
        }

        public Domain.User FindUser(int id)
        {
            return mockDataBase.FirstOrDefault(p => p.Id == 123);
        }

       

        public Task<bool> Delete(int id)
        {
            return Task.FromResult(mockDataBase.Where(p => p.Id == id).Any());

        }
    }
}
