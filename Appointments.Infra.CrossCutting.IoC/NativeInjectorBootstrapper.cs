using Appointments.Application.Interfaces;
using Appointments.Application.Services;
using Appointments.Domain.CommandHandlers;
using Appointments.Domain.Commands.Appointment;
using Appointments.Domain.Commands.AssociatePlanInfo;
using Appointments.Domain.Core.Bus;
using Appointments.Domain.Core.Notifications;
using Appointments.Domain.Interfaces;
using Appointments.Infra.CrossCutting.Bus;
using Appointments.Infra.Data.Context;
using Appointments.Infra.Data.Repository;
using Appointments.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IReferencedNetworkAppService, ReferencedNetworkAppService>();
            services.AddScoped<IAssociatePlanInfoAppService, AssociatePlanInfoAppService>();
            services.AddScoped<IAppointmentAppService, AppointmentAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Commands
            services.AddScoped<IRequestHandler<SaveAssociatePlanInfoCommand, bool>, AssociatePlanInfoCommandHandler>();
            services.AddScoped<IRequestHandler<SaveNewAppointmentRequestCommand, bool>, AppointmentCommandHandler>();

            // Infra - Data
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IAssociatePlanInfoRepository, AssociatePlanInfoRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AppointmentContext>();
        }
    }
}
