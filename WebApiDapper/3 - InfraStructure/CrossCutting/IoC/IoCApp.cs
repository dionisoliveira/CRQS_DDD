using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample._2__Domain.EventHandler;
using DDDSample._2__Domain.Interface.Repository;
using DDDSample._3___InfraStructure.Repository.EF;
using DDDSample.Application.Interface.User;
using DDDSample.Application.Service.User;
using DDDSample.CrossCutting.Bus;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Core.Events;
using DDDSample.Domain.Core.Notification;
using DDDSample.Domain.Events;
using DDDSample.Domain.EventSourcing;
using DDDSample.Domain.Interface;
using DDDSample.Domain.Interface.Services;
using DDDSample.Domain.Services;
using DDDSample.InfraStructure.Repository.User;
using DDDSample.MockData;

namespace DDDSample.CrossCutting.IoC
{
    public class IoCApp
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //Application
            services.AddScoped<IUserAppService, UserAppService>();
         
            //Infra
            // services.AddScoped<IUserRepository, UserRepository>(); //Add real data 

            //MockData
            services.AddScoped<IUserRepository, UserRepositoryMock>(); //Add to mockdata repository

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UserRegisterEvent>, UserEventHandler>();


            services.AddScoped<IUserDomainServices, UserDomainServices>();

            services.AddScoped<IMediatorHandler, MyMediatorBase>();

            services.AddScoped<IEventStore, SqlEventStore>();

            





        }
    }
}
