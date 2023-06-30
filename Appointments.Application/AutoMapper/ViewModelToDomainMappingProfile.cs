using Appointments.Application.ViewModels.Requests;
using Appointments.Domain.Commands.Appointment;
using Appointments.Domain.Commands.AssociatePlanInfo;
using Appointments.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AssociatePlanInfoViewModel, SaveAssociatePlanInfoCommand>()
                .ConstructUsing(a => new SaveAssociatePlanInfoCommand(
                    a.AssociateId,
                    a.PlanId,
                    a.PlanClassificationId,
                    a.PlanOptionId,
                    a.PlanTypeId,
                    a.PlanExpirationDate));

            CreateMap<NewAppointmentRequestViewModel, SaveNewAppointmentRequestCommand>()
                .ConstructUsing(a => new SaveNewAppointmentRequestCommand(
                    a.AssociateId,
                    a.PartnerId,
                    a.ProviderId,
                    a.ServiceTypeId,
                    a.ServiceId,
                    a.DateAndTime));
        }
    }
}
