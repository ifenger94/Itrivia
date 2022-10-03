using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.Image
{
    public class ImageDto
    {
        public int Id { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime? ModifyDate { set; get; }
        public string Code { set; get; }
        public string Url_Image { set; get; }
    }
}
