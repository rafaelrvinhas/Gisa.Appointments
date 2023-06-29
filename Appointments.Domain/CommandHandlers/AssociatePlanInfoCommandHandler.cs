using Appointments.Domain.Commands.AssociatePlanInfo;
using Appointments.Domain.Interfaces;
using Appointments.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.CommandHandlers
{
    public class AssociatePlanInfoCommandHandler : CommandHandler, IRequestHandler<SaveAssociatePlanInfoCommand, bool>
    {
        private readonly IAssociatePlanInfoRepository _associatePlanInfoRepository;

        public AssociatePlanInfoCommandHandler(IUnitOfWork uow, IAssociatePlanInfoRepository associatePlanInfoRepository) : base(uow)
        {
            _associatePlanInfoRepository = associatePlanInfoRepository;
        }

        public async Task<bool> Handle(SaveAssociatePlanInfoCommand message, CancellationToken cancellationToken)
        {
            var associatePlanInfo = new AssociatePlanInfo(
                message.AssociateId,
                message.PlanId,
                message.PlanClassificationId,
                message.PlanOptionId,
                message.PlanTypeId,
                message.PlanExpirationDate);

            _associatePlanInfoRepository.Add(associatePlanInfo);

            if (Commit())
            {

            }

            return true;
        }
    }
}
