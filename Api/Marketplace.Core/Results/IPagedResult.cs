using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Results
{
    public interface IPagedResult<T>
    {
        List<T> Items { get; set; }
        int TotalItems { get; set; }
        int TotalPages { get; set; }
        int CurrentPage { get; set; }
    }
}
