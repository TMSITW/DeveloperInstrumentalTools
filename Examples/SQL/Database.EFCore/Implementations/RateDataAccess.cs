using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Contracts;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EFCore.Implementations
{
    public class RateDataAccess : IRateDataAccess
    {
        private ExampleContext ExampleContext { get; }
        
        public RateDataAccess(ExampleContext exampleContext)
        {
            ExampleContext = exampleContext;
        }

        public async Task<IEnumerable<ExchangeRateEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.ExampleContext.Rates
                .Include(x => x.Currency)
                .OrderBy(x => x.Date)
                .ToListAsync(ct);
        }
    }
}