using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RingoMedia.EntityFrameworkCore;

namespace RingoMedia.HealthChecks
{
    public class RingoMediaDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public RingoMediaDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("RingoMediaDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("RingoMediaDbContext could not connect to database"));
        }
    }
}
