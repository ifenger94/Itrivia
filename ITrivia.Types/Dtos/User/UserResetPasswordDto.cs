using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.User
{
    public class UserResetPasswordDto
    {
        [Required]
        public int Id { set; get; }
        [Required]
        public string Password { set; get; }
        [Required]
        public string Password2 { set; get; }
    }
}
