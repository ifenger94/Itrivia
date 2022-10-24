using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITrivia.Types.Dtos.User
{
    public class UserDto
    {
        public int Id { set; get; }
        public string Email { set; get; }
        public bool IsDeleted { set; get; }
        public string Name { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime? ModifyDate { set; get; }
        public string User { set; get; }
        public string LastName { set; get; }
        public int? BussinesId { set; get; }
        public int RolId { set; get; }
        public int? ProfileId { set; get; }
        public int? ImageId { set; get; }
    }
}