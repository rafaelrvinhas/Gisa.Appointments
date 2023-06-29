using Appointments.Application.Interfaces;
using Appointments.Application.ViewModels;
using Appointments.Domain.Core.Bus;
using Appointments.Domain.Core.Notifications;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Appointments.Services.Api.Controllers
{
    [Route("api/rede-referenciada")]
    public class ReferencedNetworkController : ApiController
    {
        private readonly IReferencedNetworkAppService _referencedNetworkAppService;

        public ReferencedNetworkController(
            IReferencedNetworkAppService referencedNetworkAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _referencedNetworkAppService = referencedNetworkAppService;
        }

        [HttpGet]
        [Authorize]
        [Route("tipos-servico")]
        public IActionResult GetAvailablesServiceTypes()
        {
            var availablesServiceTypes = _referencedNetworkAppService.GetAvailableServiceTypes();
            return Response(availablesServiceTypes);
        }

        [HttpGet]
        [Authorize]
        [Route("servicos")]
        public IActionResult GetServices([FromQuery(Name = "id_tipo_servico")] int serviceTypeId)
        {
            var userData = GetUserData();

            var services = _referencedNetworkAppService.GetServices(serviceTypeId, userData.AssociateId);
            return Response(services);
        }

        [HttpGet]
        [Authorize]
        [Route("especialidades")]
        public IActionResult GetSpecialties()
        {
            var userData = GetUserData();

            var specialties = _referencedNetworkAppService.GetSpecialties(userData.AssociateId);
            return Response(specialties);
        }

        [HttpGet]
        [Authorize]
        [Route("conveniados/{id_servico}")]
        public IActionResult GetPartnersByServiceId([FromQuery(Name = "id_servico")]  int serviceId)
        {
            var userData = GetUserData();

            var partners = _referencedNetworkAppService.GetPartnersByService(serviceId, userData.AssociateId);
            return Response(partners);
        }

        [HttpGet]
        [Authorize]
        [Route("conveniados/{id_especialidade}")]
        public IActionResult GetPartnersBySpecialtyId([FromQuery(Name = "id_especialidade")] int specialtyId)
        {
            var userData = GetUserData();

            var partners = _referencedNetworkAppService.GetPartnersBySpecialty(specialtyId, userData.AssociateId);
            return Response(partners);
        }

        [HttpGet]
        [Authorize]
        [Route("prestadores/{id_especialidade}")]
        public IActionResult GetProvidersBySpecialtyId([FromQuery(Name = "id_especialidade")] int specialtyId)
        {
            var userData = GetUserData();

            var providers = _referencedNetworkAppService.GetProvidersBySpecialty(specialtyId, userData.AssociateId);
            return Response(providers);
        }

        //private UserDataViewModel GetUserData()
        //{
        //    ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
        //    IEnumerable<Claim>? userClaims = identity?.Claims;
        //    string? username = userClaims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        //    string? associateData = userClaims?.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
        //    string? Role = userClaims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

        //    int associateId = int.Parse(associateData.Split(';')[0]);
        //    int associateCategoryId = int.Parse(associateData.Split(';')[1]);

        //    return new UserDataViewModel(username, associateId, associateCategoryId);
        //}
    }
}
