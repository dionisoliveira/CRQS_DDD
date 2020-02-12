using System;
using DDDSample.Application.Interface.User;
using DDDSample.Application.Model;
using DDDSample.Domain.Interface;
using DDDSample.Domain.Interface.Services;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Command;
using DDDSample.Domain.Commands;
using DDDSample._2__Domain.Query;

namespace DDDSample.Application.Service.User
{
    public class UserAppService : IUserAppService
    {

        #region private
        private IUserDomainServices _userRepository;
        private IMediatorHandler _mediator;
    

        #endregion

        public UserAppService(IUserDomainServices userRepository,
                              IMediatorHandler bus, IUserRepository user)
        {
            _userRepository = userRepository;
            _mediator = bus;
    
        }





        /// <summary>
        /// Find user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserViewModel FindUser(int id)
        {
            var alunoQuery = new UserFindIDQuery(id);

            var result = _mediator.Send(alunoQuery);

            return new UserViewModel
            {
                Id = result.Result.Id,
                Name = result.Result.Name,
            };

        }
        

        public void SaveUser(UserViewModel user)
        {
            var registerCommand = new UserRegisterCommand( user.Name, DateTime.Now);

            var result =_mediator.Send(registerCommand);


        }

        public void DeleteUser(int id)
        {
            var deleteCommand = new UserDeleteCommand(id);

            _mediator.SendCommand(deleteCommand);


        }
    }
}
