using Appointments.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.ViewModels.Responses
{
    public class AvailableServiceTypesViewModel
    {
        public List<ServiceTypeViewModel> AvailableServiceTypes
        {
            get
            {
                return new List<ServiceTypeViewModel>
                {
                    new ServiceTypeViewModel((int)EServiceTypeViewModel.Consultation, GetServiceTypeName(EServiceTypeViewModel.Consultation)),
                    new ServiceTypeViewModel((int)EServiceTypeViewModel.Exam, GetServiceTypeName(EServiceTypeViewModel.Exam)),
                    new ServiceTypeViewModel((int)EServiceTypeViewModel.Therapy, GetServiceTypeName(EServiceTypeViewModel.Therapy))
                };
            }
        }

        private static string GetServiceTypeName(EServiceTypeViewModel eServiceType)
        {
            switch (eServiceType)
            {
                case EServiceTypeViewModel.Consultation:
                    return "Consulta";
                case EServiceTypeViewModel.Exam:
                    return "Exame";
                case EServiceTypeViewModel.Therapy:
                    return "Terapia";
                default:
                    return "Consulta";
            }
        }
    }
}
