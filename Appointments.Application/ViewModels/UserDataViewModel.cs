using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.ViewModels
{
    public class UserDataViewModel
    {
        public UserDataViewModel(string email, int associateId, int associateCategoryId)
        {
            Email = email;
            AssociateId = associateId;
            AssociateCategoryId = associateCategoryId;
        }

        public string Email { get; set; }
        public int AssociateId { get; set; }
        public int AssociateCategoryId { get; set; }
    }
}
