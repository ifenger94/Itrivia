using ITrivia.Types.Dtos.Image;
using ITrivia.Types.Dtos.Profile;
using ITrivia.Types.Dtos.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.User
{
    public class UserDetailDto : UserDto
    {
        public ImageDto Image { set; get; }
        public RolDto Rol { set; get; }
        public ProfileDto Profile { set; get; }
    }
}
