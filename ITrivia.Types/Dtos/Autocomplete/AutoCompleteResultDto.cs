using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.Autocomplete
{
    public class AutoCompleteResultDto
    {
        public bool valid { set; get; }
        public string answer { set; get; }
    }
}
