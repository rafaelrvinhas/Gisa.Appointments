using Appointments.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Services.Api.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<AppointmentContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppointmentsDbConnection")));
        }
    }
}
