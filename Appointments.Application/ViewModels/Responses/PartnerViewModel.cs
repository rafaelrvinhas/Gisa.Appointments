using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointments.Application.ViewModels.Base;
using Appointments.Application.ViewModels.Enums;

namespace Appointments.Application.ViewModels.Responses
{
    public class PartnerViewModel : PlanLevelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EPartnerTypeViewModel PartnerType { get; set; }
    }
}
