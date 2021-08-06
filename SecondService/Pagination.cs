using System.Collections.Generic;

namespace SecondService
{
    public class Pagination<T>
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
