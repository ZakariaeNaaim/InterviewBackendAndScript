using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http;
using App.WebApi.Wrappers;
using Application.Dtos;

namespace WebApi.Controllers
{
    [RoutePrefix("api/metrics")]
    public class MetricsController : ApiController
    {
        private readonly MetricsService _metricsService;

        public MetricsController(MetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<AppResult<MetricsResultDto>> Get(int topNSku = 5)
        {
            var result = await _metricsService.GetMetricsAsync(topNSku);

            if (result == null)
                return AppResult<MetricsResultDto>.NotFound();

            return AppResult<MetricsResultDto>.Ok(result);
        }
    }
}
