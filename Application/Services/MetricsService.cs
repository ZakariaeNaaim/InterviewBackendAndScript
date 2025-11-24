using Application.Dtos;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IServices;
using Application.Mappers;
using System.Linq;
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
            if (topN <= 0)
            {
                throw new ValidationException(
                    nameof(topN),
                    "The number of top SKUs must be greater than zero.");
            }

            var orders = await _csvOrderRepo.GetAllAsync().ConfigureAwait(false);

            if (!orders.Any())
                throw new BusinessRuleException(nameof(GetMetricsAsync),"No orders data available to compute metrics.");

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
