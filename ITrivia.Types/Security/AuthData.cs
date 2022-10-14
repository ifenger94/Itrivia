using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Security
{
    public class AuthData
    {
        public DateTime LifeTime { get; set; }
        public int? ProfileID { get; set; }
        public string RolCode { get; set; }
        public string JWT { get; set; }
        public int UserID { get; set; }
    }
}
