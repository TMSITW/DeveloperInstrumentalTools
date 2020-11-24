using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Entities;

namespace Database.EFCore.Contracts
{
    public interface IWeatherDataAccess
    {
        Task<IEnumerable<WeatherEntity>> GetAllAsync(CancellationToken ct = default);
    }
}