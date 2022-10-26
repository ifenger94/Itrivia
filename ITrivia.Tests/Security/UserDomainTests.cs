using ITrivia.Contracts.Repository;
using ITrivia.Domain.Base;
using ITrivia.Domain.Security;
using ITrivia.Types.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Tests.Security
{
    public class UserDomainTests
    {
        private readonly UserDomain _userDomain;
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly SegTusuario _testUser;

        public UserDomainTests()
        {
            _userDomain = new UserDomain(_userRepositoryMock.Object);
            _testUser = new SegTusuario()
            {
                Nombre = "Pepe",
                Apellido = "Argento",
                Password = "PepeArgento1@",
                Id = 20
            };
        }

        [Fact]
        public void Create_ShouldReturnUser()
        {
            _userRepositoryMock.Setup(x => x.Create(_testUser)).Returns(_testUser);

            var newUser = _userDomain.Create(_testUser);

            Assert.NotNull(newUser);
            Assert.NotEmpty(newUser.Password);
        }
    }
}
