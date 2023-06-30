using Appointments.Application.ViewModels.Requests;
using Appointments.Application.ViewModels.Responses;
using Appointments.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Service, ServiceViewModel>();
            CreateMap<AssociatePlanInfo, AssociatePlanInfoViewModel>();
            CreateMap<Appointment, AppointmentViewModel>();
            CreateMap<Partner, PartnerViewModel>();
            CreateMap<Provider, ProviderViewModel>();
            CreateMap<Specialty, SpecialtyViewModel>();
        }
    }
}
