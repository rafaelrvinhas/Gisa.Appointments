using Appointments.Application.ViewModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Interfaces
{
    public interface IReferencedNetworkAppService : IDisposable
    {
        AvailableServiceTypesViewModel GetAvailableServiceTypes();
        IEnumerable<ServiceViewModel> GetServices(int serviceTypeId, int associateId);
        IEnumerable<SpecialtyViewModel> GetSpecialties(int associateId);
        IEnumerable<PartnerViewModel> GetPartnersByService(int specialtyId, int associateId);
        IEnumerable<PartnerViewModel> GetPartnersBySpecialty(int specialtyId, int associateId);
        IEnumerable<ProviderViewModel> GetProvidersByPartner(int partnerId, int associateId);
        IEnumerable<ProviderViewModel> GetProvidersBySpecialty(int specialtyId, int associateId);
    }
}
