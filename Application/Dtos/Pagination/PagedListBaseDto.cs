using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Application.Dtos.Pagination
{
    public class PagedListBaseDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortColumn { get; set; }
        public bool IsAscending { get; set; } = true;
    }
}
