using ITrivia.Contracts.Repository;
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
    public class RolDomainTests
    {
        private readonly RolDomain _rolDomain;
        private readonly Mock<IRolRepository> _rolRepositoryMock = new Mock<IRolRepository>();

        public RolDomainTests()
        {
            _rolDomain = new RolDomain(_rolRepositoryMock.Object);
        }

        [Fact]
        public void GetRolCodeById_ShouldReturnStringCode_WhenCodeIsGreaterThanZero()
        {
            var codeToSearch = 1;
            _rolRepositoryMock.Setup(x => x.ReadOne(codeToSearch)).Returns(new SegProle() { Codigo = "1" });

            var expectedCode = _rolDomain.GetRolCodeById(codeToSearch);

            Assert.Equal(expectedCode, codeToSearch.ToString());

        }

    }
}
