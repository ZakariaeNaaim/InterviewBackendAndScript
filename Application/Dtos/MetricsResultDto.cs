using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class MetricsResultDto
    {
        public Dictionary<DateTime, int> DailyTotals { get; set; } 
        public List<string> TopSkus { get; set; }
        public MetricsResultDto()
        {
            DailyTotals = new Dictionary<DateTime, int>();
            TopSkus = new List<string>();
        }
    }
}
