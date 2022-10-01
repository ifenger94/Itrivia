using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.Domain.Base;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Domain.Parameter
{
    public class ImageDomain : DomainBase<IImageRepository, ParPimagene>, IImageDomain
    {
        public ImageDomain(IImageRepository imageRepository) : base(imageRepository)
        {
        }

        public int? GetIdByCode(string code)
        {
            int? id = null;
            ParPimagene image = GetAllBy(e => e.Codigo == code && e.Baja == false).FirstOrDefault();
            if (image != null) id = image.Id;
            return id;
        }
    }
}
