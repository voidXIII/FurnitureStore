using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Specifications
{
    public class ParamsSpecification
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 0;
        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? StatusId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }
        public string Search { get; set; }
    }
}