using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Appointments.Application.ViewModels.Responses
{
    public class ServiceTypeViewModel
    {
        public ServiceTypeViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Name { get; set; }
    }
}
