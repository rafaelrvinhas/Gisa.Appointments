using Appointments.Application.Interfaces;
using Appointments.Application.ViewModels.Requests;
using Appointments.Domain.Core.Bus;
using Appointments.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Services.Api.Controllers
{
    [Route("api/agendamento")]
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentAppService _appointmentAppService;

        public AppointmentController(
            IAppointmentAppService appointmentAppService,
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _appointmentAppService = appointmentAppService;
        }

        [HttpPost]
        [Authorize]
        [Route("novo")]
        public IActionResult Post([FromBody] NewAppointmentRequestViewModel newAppointmentRequestViewModel)
        {
            var userData = GetUserData();

            _appointmentAppService.RequestNewAppointment(newAppointmentRequestViewModel, userData.AssociateId);
            return Ok();
        }
    }
}
