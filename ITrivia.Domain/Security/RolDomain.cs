using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.Domain.Base;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Domain.Security
{
    public class RolDomain : DomainBase<IRolRepository, SegProle>, IRolDomain
    {
        public RolDomain(IRolRepository rolRepository) : base(rolRepository)
        {
        }

        public int GetRolIdByCode(string code)
        {
            return this.GetAllBy(e => e.Codigo == code && e.Baja == false).FirstOrDefault().Id;
        }

        public string GetRolCodeById(int id)
        {
            string code = string.Empty;
            if (id > 0) code = this.Get(id).Codigo;
            return code;

        }
    }
}
