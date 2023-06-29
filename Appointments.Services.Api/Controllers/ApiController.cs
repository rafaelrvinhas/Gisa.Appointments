using Appointments.Application.ViewModels;
using Appointments.Domain.Core.Bus;
using Appointments.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Appointments.Services.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected ApiController(INotificationHandler<DomainNotification> notifications,
                                IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            //_mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotifyError(result.ToString(), error.Description);
            }
        }

        protected UserDataViewModel GetUserData()
        {
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim>? userClaims = identity?.Claims;
            string? username = userClaims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            string? associateData = userClaims?.FirstOrDefault(x => x.Type == "sid").Value;
            string? Role = userClaims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            int associateId = int.Parse(associateData.Split(';')[0]);
            int associateCategoryId = int.Parse(associateData.Split(';')[1]);

            return new UserDataViewModel(username, associateId, associateCategoryId);
        }
    }
}
