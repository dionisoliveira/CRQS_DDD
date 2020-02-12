using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Application.Model;

namespace DDDSample.Application.Factory
{
    public class UserViewModelFactory
    {
        public static UserViewModel ToUserViewModel(string name, int id)
        {
            return new UserViewModel()
            {
                //Id = id,
                Name = name
            };
        }
    }
}
