using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class MetricsResultDtoMapper
    {
        public static MetricsResultDto Map(Dictionary<DateTime, int> dailyTotals, List<string> topSkus)
        {
            return new MetricsResultDto
            {
                DailyTotals = dailyTotals,
                TopSkus = topSkus
            };
        }
    }
}
