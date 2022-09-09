using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Contracts.Domain
{
    public interface IUserDomain : IDomainBase<SegTusuario>
    {
        SegTusuario GetByEmail(string email);

        void ResetPassword(int id, string password);
        void UpdateUser(SegTusuario entity);

    }
}
