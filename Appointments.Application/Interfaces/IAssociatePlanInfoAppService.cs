using Appointments.Application.ViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Interfaces
{
    public interface IAssociatePlanInfoAppService : IDisposable
    {
        void SaveAssociatePlanInfo(AssociatePlanInfoViewModel associatePlanInfo);
    }
}
