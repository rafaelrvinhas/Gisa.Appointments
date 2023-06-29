using Appointments.Application.Interfaces;
using Appointments.Application.ViewModels.Requests;
using Appointments.Domain.Commands.AssociatePlanInfo;
using Appointments.Domain.Core.Bus;
using Appointments.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Services
{
    public class AssociatePlanInfoAppService : IAssociatePlanInfoAppService
    {
        private readonly IMapper _mapper;
        IAssociatePlanInfoRepository _associatePlanInfoRepository;
        private readonly IMediatorHandler Bus;

        public AssociatePlanInfoAppService(
            IMapper mapper,
            IAssociatePlanInfoRepository associatePlanInfoRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _associatePlanInfoRepository = associatePlanInfoRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async void SaveAssociatePlanInfo(AssociatePlanInfoViewModel associatePlanInfo)
        {
            var command = _mapper.Map<SaveAssociatePlanInfoCommand>(associatePlanInfo);
            await Bus.SendCommand(command);
        }
    }
}
