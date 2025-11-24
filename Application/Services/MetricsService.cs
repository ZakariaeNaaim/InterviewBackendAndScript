using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.IServices;
using Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MetricsService : IMetricsService
    {
        private readonly ICsvOrderRepository _csvOrderRepo;

        public MetricsService(ICsvOrderRepository csvOrderRepo)
        {
            _csvOrderRepo = csvOrderRepo;
        }

        public async Task<MetricsResultDto> GetMetricsAsync(int topN)
        {
            var orders = await _csvOrderRepo.GetAllAsync();

            var dailyTotals = orders
                .GroupBy(o => o.OrderDate.Date)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity));

            var topSkus = orders
                .GroupBy(o => o.Sku)
                .OrderByDescending(g => g.Sum(x => x.Quantity))
                .Take(topN)
                .Select(g => g.Key)
                .ToList();

            return MetricsResultDtoMapper.Map(dailyTotals, topSkus);
        }
    }
}
