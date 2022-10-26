using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.MultipleChoice
{
    public class MultipleChoiceDto
    {
        public int Id { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime? ModifyDate { set; get; }
        public string User { set; get; }
        public string Enunciate { set; get; }
        public string CorrectOption { set; get; }
        public string FirstOption { set; get; }
        public string SecondOption { set; get; }
    }
}
