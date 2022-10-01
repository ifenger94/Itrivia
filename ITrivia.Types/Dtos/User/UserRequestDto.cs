using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.User
{
    public class UserRequestDto
    {
        
        [Required]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
        [Required]
        public string Password2 { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string LastName { set; get; }

    }

    public class UserUpdateRequestDto
    {
        [Required]
        public int Id { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string LastName { set; get; }

    }
}
