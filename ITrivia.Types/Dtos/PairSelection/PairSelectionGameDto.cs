using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.PairSelection
{
    public class PairSelectionGameDto
    {
        public int Id { set; get; }
        public List<PairOption> PairOptions { set; get; }
    }

    public class PairOption
    {
        public string Option { set; get; }
        public string Pair { set; get; }
    }
}
