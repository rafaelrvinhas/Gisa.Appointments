using Appointments.Application.Interfaces;
using Appointments.Application.ViewModels.Requests;
using Appointments.Domain.Core.Bus;
using Appointments.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

            newAppointmentRequestViewModel.SetDateAndTime();

            _appointmentAppService.RequestNewAppointment(newAppointmentRequestViewModel, userData.AssociateId);
            return Ok();
        }

        [HttpGet]
        [Route("historico")]
        public IActionResult Get([FromQuery(Name = "id_associado")]int associateId)
        {
            var appointments = _appointmentAppService.GetAppointments(associateId);
            return Ok(appointments);
        }

        [HttpPut]
        [Route("atualiza")]
        public IActionResult Put([FromQuery(Name = "id_agendamento")]int appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
