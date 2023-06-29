using Appointments.Application.Interfaces;
using Appointments.Application.ViewModels.Requests;
using Appointments.Application.ViewModels.Responses;
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
    public class ReferencedNetworkAppService : IReferencedNetworkAppService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;
        private readonly IAssociatePlanInfoRepository _associatePlanInfoRepository;
        private readonly IMediatorHandler Bus;

        public ReferencedNetworkAppService(
            IMapper mapper,
            IServiceRepository serviceRepository,
            IAssociatePlanInfoRepository associationPlanInfoRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _associatePlanInfoRepository = associationPlanInfoRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AvailableServiceTypesViewModel GetAvailableServiceTypes()
        {
            return new AvailableServiceTypesViewModel();
        }

        public IEnumerable<ServiceViewModel> GetServices(int serviceTypeId, int associateId)
        {
            var associatePlanInfo = _mapper.Map<AssociatePlanInfoViewModel>(_associatePlanInfoRepository.GetAssociatePlanDetails(associateId));

            return _mapper.Map<IEnumerable<ServiceViewModel>>(
                _serviceRepository.GetServices(
                    serviceTypeId,
                    associatePlanInfo.PlanClassificationId,
                    associatePlanInfo.PlanOptionId));
        }

        public IEnumerable<PartnerViewModel> GetPartnersByService(int serviceId, int associateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PartnerViewModel> GetPartnersBySpecialty(int specialtyId, int associateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProviderViewModel> GetProvidersByPartner(int partnerId, int associateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProviderViewModel> GetProvidersBySpecialty(int specialtyId, int associateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpecialtyViewModel> GetSpecialties(int associateId)
        {
            throw new NotImplementedException();
        }
    }
}
