using System.Collections.Generic;

namespace RepositoryPattern.Data.Models
{
    public class PaginationResponseModel<T>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Items  { get; set; }
    }
}
