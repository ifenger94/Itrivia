using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Security
{
    public class AuthData
    {
        public DateTime LifeTime { set; get; }
        public int? ProfileId { set; get; }
        public string RolCode { get; set; }
        public string Jwt { get; set; }
        public int UserId { set; get; }
    }
}
