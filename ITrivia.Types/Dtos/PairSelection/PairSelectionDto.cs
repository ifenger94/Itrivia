using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.PairSelection
{
    public class PairSelectionDto
    {
        public int Id { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime? ModifyDate { set; get; }
        public string User { set; get; }
        public string FirstOption { set; get; }
        public string FirstAnswer { set; get; }
        public string SecondOption { set; get; }
        public string SecondAnswer { set; get; }
        public string ThirdOption { set; get; }
        public string ThirdAnswer { set; get; }
        public string FourthOption { set; get; }
        public string FourthAnswer { set; get; }
    }
}
