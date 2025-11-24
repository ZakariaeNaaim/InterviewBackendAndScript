using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Orders
{
    public class CsvOrderRepository : ICsvOrderRepository
    {
        private readonly string _csvPath;

        public CsvOrderRepository(string csvPath)
        {
            _csvPath = csvPath;
        }


        public async Task<List<CsvOrder>> GetAllAsync()
        {
            var result = new List<CsvOrder>();

            if (!File.Exists(_csvPath)) return result;

            using (var stream = new FileStream(_csvPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream))
            {
                string line;
                bool isHeader = true;

                while ((line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
                {
                    if (isHeader)
                    {
                        isHeader = false;
                        continue; 
                    }

                    var parts = line.Split(',');
                    if (parts.Length < 7) continue; 

                    if (!int.TryParse(parts[0], out int id)) continue;

                    var customerName = (parts[1] ?? string.Empty).Trim();
                    var sku = (parts[2] ?? string.Empty).Trim();

                    if (!int.TryParse(parts[3], NumberStyles.Integer, CultureInfo.InvariantCulture, out int qty)) continue;
                    if (qty <= 0) continue;

                    if (!decimal.TryParse(parts[4], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal unitPrice)) continue;

                    if (!DateTime.TryParse(parts[5], CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTime orderDate)) continue;

                    var status = (parts[6] ?? string.Empty).Trim();

                    var row = new CsvOrder
                    {
                        Id = id,
                        CustomerName = customerName,
                        Sku = sku,
                        Quantity = qty,
                        UnitPrice = unitPrice,
                        OrderDate = orderDate,
                        Status = status
                    };

                    result.Add(row);
                }
            }

            return result;
        }
    }
}
