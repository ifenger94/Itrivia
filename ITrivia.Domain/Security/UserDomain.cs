using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.Domain.Base;
using ITrivia.Helpers;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Domain.Security
{
    public class UserDomain : DomainBase<IUserRepository, SegTusuario>, IUserDomain
    {
        public UserDomain(IUserRepository userRepository) : base(userRepository)
        {
        }

        public SegTusuario GetByEmail(string email)
        {
            return GetAllBy(e => e.Email.ToLower() == email.ToLower() && e.Baja == false).FirstOrDefault();
        }

        public override SegTusuario Create(SegTusuario entity)
        {
            string hashPassword = HashHelper.Hash(entity.Password);
            entity.Password = hashPassword;
            entity.AltaFecha = DateTime.Now;
            //entity.Usuario = JwtHelper.instace.GetCurrentUser();
            return base.Create(entity);
        }

        public void ResetPassword(int id, string password)
        {
            SegTusuario user = Get(id);
            user.Password = HashHelper.Hash(password);
            Update(user);
        }

        public void UpdateUser(SegTusuario entity)
        {
            if (!GetAllBy(e => e.Email == entity.Email && e.Id != entity.Id && e.Baja == false).Any())
            {
                SegTusuario user = Get(entity.Id);
                user.Nombre = entity.Nombre;
                user.Apellido = entity.Apellido;
                user.Email = entity.Email;
                Update(user);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
