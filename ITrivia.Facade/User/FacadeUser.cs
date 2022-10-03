using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Types.Dtos.User;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Facade.User
{

    public class FacadeUser : IFacadeUser
    {
        private IUserDomain userDomain { set; get; }
        private IProfileDomain profileDomain { set; get; }
        private IRolDomain rolDomain { set; get; }
        private IImageDomain imageProfileDomain { set; get; }

        public FacadeUser(IUserDomain userDomain, IProfileDomain profileDomain, IRolDomain rolDomain, IImageDomain imageProfileDomain)
        {
            this.profileDomain = profileDomain;
            this.userDomain = userDomain;
            this.rolDomain = rolDomain;
            this.imageProfileDomain = imageProfileDomain;
        }

        public SegTusuario GenerateUser(SegTusuario user)
        {
            if (user == null) return user;

            user.IdRol = rolDomain.GetRolIdByCode("USER");
            user.IdImagen = imageProfileDomain.GetIdByCode("USER");

            GesTperfile profile = new GesTperfile() { Exp = 0 };
            profileDomain.Create(profile);

            user.IdPerfil = profile.Id;
            this.userDomain.Create(user);

            return user;
        }

        public IEnumerable<SummaryUserProfileDto> GetSummaryUserProfile()
        {
            List<SummaryUserProfileDto> summary = new List<SummaryUserProfileDto>();

            //SegTusuario currentUser = userDomain.GetByEmail(JwtHelper.instace.GetCurrentUser());
            SegTusuario currentUser = userDomain.GetAll().FirstOrDefault();
            
            Expression<Func<SegTusuario, bool>> expression = (e => e.Baja == false && e.IdPerfil != null);

            IEnumerable<SegTusuario> users = userDomain.GetAllBy(expression).OrderByDescending(e => e.IdPerfilNavigation.Exp).Take(10);

            foreach (var user in users)
            {
                summary.Add(new SummaryUserProfileDto()
                {
                    Email = user.Email,
                    FullName = user.Nombre + " " + user.Apellido,
                    Experience = user.IdPerfilNavigation.Exp
                });
            }

            return summary;
        }
    }
}

