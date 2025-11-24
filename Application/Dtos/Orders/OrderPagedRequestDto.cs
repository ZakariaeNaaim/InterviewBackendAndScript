using Application.Dtos.Pagination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Orders
{
    public class OrderPagedRequestDto : PagedListBaseDto
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Status { get; set; }
    }
}
