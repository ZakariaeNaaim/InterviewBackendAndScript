using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class MetricsServiceTests
    {
        [Test]
        public async Task GetMetricsAsync_ShouldReturnDailyTotalsAndTopSkus()
        {
            var mockRepo = new Mock<ICsvOrderRepository>();

            var fakeOrders = new List<CsvOrder>
            {
                new CsvOrder { Id=1, CustomerName="Alice", Sku="Widget-A", Quantity=2, UnitPrice=50, OrderDate=new DateTime(2024,1,5), Status="Pending" },
                new CsvOrder { Id=2, CustomerName="Bob", Sku="Gadget-B", Quantity=5, UnitPrice=75, OrderDate=new DateTime(2024,1,5), Status="Completed" },
                new CsvOrder { Id=3, CustomerName="Charlie", Sku="Widget-A", Quantity=3, UnitPrice=50, OrderDate=new DateTime(2024,1,6), Status="Completed" }
            };

            mockRepo.Setup(r => r.GetAllAsync())
                    .ReturnsAsync(fakeOrders);

            var service = new MetricsService(mockRepo.Object);

            var result = await service.GetMetricsAsync(2);

            Assert.That(result.DailyTotals[new DateTime(2024, 1, 5)], Is.EqualTo(7)); // 2+5
            Assert.That(result.DailyTotals[new DateTime(2024, 1, 6)], Is.EqualTo(3));
            Assert.That(result.TopSkus, Does.Contain("Widget-A"));
            Assert.That(result.TopSkus, Does.Contain("Gadget-B"));
        }
    }
}
