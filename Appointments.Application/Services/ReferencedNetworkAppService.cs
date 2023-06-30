using Appointments.Application.Interfaces;
using Appointments.Application.ViewModels.Requests;
using Appointments.Application.ViewModels.Responses;
using Appointments.Domain.Core.Bus;
using Appointments.Domain.Interfaces;
using Appointments.Domain.Models;
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
        private readonly IPartnerRepository _partnerRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IMediatorHandler Bus;

        public ReferencedNetworkAppService(
            IMapper mapper,
            IServiceRepository serviceRepository,
            IAssociatePlanInfoRepository associationPlanInfoRepository,
            IPartnerRepository partnerRepository,
            ISpecialtyRepository specialtyRepository,
            IProviderRepository providerRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _associatePlanInfoRepository = associationPlanInfoRepository;
            _partnerRepository = partnerRepository;
            _specialtyRepository = specialtyRepository;
            _providerRepository = providerRepository;
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

        public IEnumerable<PartnerViewModel> GetPartners(int associateId)
        {
            var associatePlanInfo = _mapper.Map<AssociatePlanInfoViewModel>(_associatePlanInfoRepository.GetAssociatePlanDetails(associateId));

            return _mapper.Map<IEnumerable<PartnerViewModel>>(
                _partnerRepository.GetPartners(
                    associatePlanInfo.PlanClassificationId,
                    associatePlanInfo.PlanOptionId));
        }

        public IEnumerable<ProviderViewModel> GetProvidersByPartner(int partnerId, int associateId)
        {
            var associatePlanInfo = _mapper.Map<AssociatePlanInfoViewModel>(_associatePlanInfoRepository.GetAssociatePlanDetails(associateId));

            return _mapper.Map<IEnumerable<ProviderViewModel>>(
                _providerRepository.GetProvidersByPartner(
                    partnerId,
                    associatePlanInfo.PlanClassificationId,
                    associatePlanInfo.PlanOptionId));
        }

        public IEnumerable<ProviderViewModel> GetProvidersBySpecialty(int specialtyId, int associateId)
        {
            var associatePlanInfo = _mapper.Map<AssociatePlanInfoViewModel>(_associatePlanInfoRepository.GetAssociatePlanDetails(associateId));

            return _mapper.Map<IEnumerable<ProviderViewModel>>(
                _providerRepository.GetProvidersBySpecialty(
                    specialtyId, 
                    associatePlanInfo.PlanClassificationId, 
                    associatePlanInfo.PlanOptionId));
        }

        public IEnumerable<SpecialtyViewModel> GetSpecialties(int associateId)
        {
            var associatePlanInfo = _mapper.Map<AssociatePlanInfoViewModel>(_associatePlanInfoRepository.GetAssociatePlanDetails(associateId));

            return _mapper.Map<IEnumerable<SpecialtyViewModel>>(
                _specialtyRepository.GetSpecialties(
                    associatePlanInfo.PlanClassificationId,
                    associatePlanInfo.PlanOptionId));
        }
    }
}
