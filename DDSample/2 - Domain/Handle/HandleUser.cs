using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DDDSample._2__Domain.Handle;
using DDDSample._2__Domain.Query;
using DDDSample.Domain;
using DDDSample.Domain.Command;
using DDDSample.Domain.Commands;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Core.Notification;
using DDDSample.Domain.Events;
using DDDSample.Domain.Interface;

namespace DDDSample._2__Domain
{
    public class HandleUser : CommandHandler,
        IRequestHandler<UserRegisterCommand,bool>,
        IRequestHandler<UserDeleteCommand, bool>

      

    {
        private readonly IUserRepository _userRepository;
     

        public HandleUser(IUserRepository userRepository,
                          //IUnitOfWork uow,
                          IMediatorHandler mediator,
                          INotificationHandler<DomainNotification> notifications) : base(mediator, notifications)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handle controll register commandfor new User
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                this.NotifyValidationErrors(request);
                return await Task.FromResult(false);
            }

            //Create object for save to database 
            var user = new User
            {
               
                Name = request.Name,
                BirthDate = request.BirthDate

            };

           var id = await _userRepository.Save(user); //Save in database

            await MediatorHandler.RaiseEvent(new UserRegisterEvent(id, request.Name,request.BirthDate));


            return await Task.FromResult(true); 
          
        }


        /// <summary>
        /// Handle control command for delete user for database.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> Handle(UserDeleteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _userRepository.Delete(Convert.ToInt32(message.Id));

            if (Commit())
            {
                MediatorHandler.RaiseEvent(new UserDeleteEvent(message.Id));
            }

            return Task.FromResult(true);
        }


        /// <summary>
        /// Handle control find by user 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> Handle(UserFindIDQuery message, CancellationToken cancellationToken)
        {


            var user  = _userRepository.FindUser(message.Id);


            MediatorHandler.RaiseEvent(new UserRegisterEvent(user.Id, user.Name,user.BirthDate));

            return Task.FromResult(true);
        }
    }
}
