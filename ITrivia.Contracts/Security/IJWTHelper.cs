using ITrivia.Types.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Contracts.Security
{
    public interface IJWTHelper
    {
        UserToken GenerateToken(string username, double minutes);
        UserToken RefreshToken(string token, double minutes);
    }
}
