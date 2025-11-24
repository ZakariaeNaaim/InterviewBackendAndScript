using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Pagination
{
    public class PagedListBaseDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "PageNumber must be at least 1.")]
        public int Page { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "PageSize must be between 1 and 100.")]
        public int PageSize { get; set; } = 20;
        public string SortColumn { get; set; }
        public bool IsAscending { get; set; } = true;
    }
}
