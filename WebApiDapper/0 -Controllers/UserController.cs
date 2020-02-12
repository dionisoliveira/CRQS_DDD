using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using DDDSample.Application.Interface.User;
using DDDSample._0__Controllers;
using MediatR;
using DDDSample.Domain.Core.Notification;
using DDDSample.Domain.Core.Bus;
using DDDSample.Application.Model;

namespace DDDSample.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ApiController
    {

        private readonly ILogger<UserController> _logger;

        private readonly IConfiguration _config;

        private IUserAppService _userAppService;



      

        public UserController(
                                       
                                        INotificationHandler<DomainNotification> notifications,
                                        IMediatorHandler mediator,
                                        ILogger<UserController> logger,
                                        [FromServices]IConfiguration config,
                                        IUserAppService userAppService) : base(notifications, mediator)
        {
            _logger = logger;
            _config = config;
            _userAppService = userAppService;//1 -> Application -> Service -> User -> UserAppService
        }





        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser(UserViewModel user)
        {
           

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(user);
            }

            _userAppService.SaveUser(user);

       

            return Response(user);


        }

        [HttpGet]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int Id)
        {



            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(Id);
            }

            _userAppService.DeleteUser(Id);


            return Response(Id);


        }

        [HttpGet]
        [Route("FindUserById")]
        public IActionResult FindUserById(int id)
        {

            var usuario = _userAppService.FindUser(id);

            return Response(usuario);



        }

        

    }
}
