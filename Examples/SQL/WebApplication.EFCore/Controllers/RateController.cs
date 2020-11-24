using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Database.EFCore.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateController : ControllerBase
    {
        private ILogger<RateController> Logger { get; }
        private IRateDataAccess RateDataAccess { get; }
        private IMapper Mapper { get;  }
        

        public RateController(ILogger<RateController> logger, IRateDataAccess rateDataAccess, IMapper mapper)
        {
            Logger = logger;
            RateDataAccess = rateDataAccess;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ExchangeRate>> Get(CancellationToken ct = default)
        {
            this.Logger.LogDebug($"{nameof(RateController)}.{nameof(Get)} executed");
            
            return this.Mapper.Map<IEnumerable<ExchangeRate>>(await this.RateDataAccess.GetAllAsync(ct));
        }
    }
}