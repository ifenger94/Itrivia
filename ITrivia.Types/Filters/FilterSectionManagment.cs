using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Filters
{
    public class FilterSectionManagment
    {
        public int ProfileId { set; get; }
        public int? CategoryId { set; get; }
        public string Search { set; get; }
    }
}
