using Appointments.Application.Interfaces;
using Appointments.Application.ViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Services.WorkerService
{
    public class App
    {
        private readonly IAssociatePlanInfoAppService _associatePlanInfoAppService;

        public App(IAssociatePlanInfoAppService associatePlanInfoAppService)
        {
            _associatePlanInfoAppService = associatePlanInfoAppService;
        }

        public void Run(AssociatePlanInfoViewModel associatePlanInfo)
        {
            _associatePlanInfoAppService.SaveAssociatePlanInfo(associatePlanInfo);
        }
    }
}
