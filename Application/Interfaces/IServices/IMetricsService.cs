using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IMetricsService
    {
        Task<MetricsResultDto> GetMetricsAsync(int topN);
    }
}
