using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DDDSample.Domain;
using DDDSample.Domain.Interface;
using DDDSample.InfraStructure.Repository;

namespace DDDSample.MockData
{
    public class UserRepositoryMock : BaseRepository, IUserRepository
    {
        
        private List<User> GerarMockDados()
        {

             return new List<User>()
            { new User()
            {
                Id = 10,
               
                Name = "Laura",

            },
            new User()
            {
                Id = 11,
              
                Name = "Pedro",

            },
            new User()
            {
                Id = 12,
             
                Name = "Maria",

            } };
        }





        public UserRepositoryMock([FromServices] IConfiguration config) : base(config, "")
        {
        }




        public async Task<int> Save(Domain.User user)
        {
            GerarMockDados().Add(user);
            return 12344;//Return fakeGuid
        }

        public Domain.User FindUser(int id)
        {
            return GerarMockDados().FirstOrDefault();
        }

       

        public Task<bool> Delete(int id)
        {

            return Task.FromResult<bool>(false);
        }
    }
}

