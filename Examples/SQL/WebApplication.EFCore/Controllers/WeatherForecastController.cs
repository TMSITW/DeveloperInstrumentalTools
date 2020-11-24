using System;
using System.Collections.Generic;
using System.Linq;
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
    public class WeatherForecastController : ControllerBase
    {
        private ILogger<WeatherForecastController> Logger { get; }
        private IWeatherDataAccess WeatherDataAccess { get; }
        private IMapper Mapper { get;  }
        

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherDataAccess weatherDataAccess, IMapper mapper)
        {
            Logger = logger;
            WeatherDataAccess = weatherDataAccess;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get(CancellationToken ct = default)
        {
            this.Logger.LogDebug($"{nameof(WeatherForecastController)}.{nameof(Get)} executed");
            
            return this.Mapper.Map<IEnumerable<WeatherForecast>>(await this.WeatherDataAccess.GetAllAsync(ct));
        }
    }
}