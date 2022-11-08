using ITrivia.Contracts.Repository;
using ITrivia.Domain.Management;
using ITrivia.Types.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Tests.Management
{
    public class AutocompleteDomainTests
    {
        private readonly AutocompleteDomain _autocompleteDomain;
        private readonly Mock<IAutocompleteRepository> _autocompleteRepositoryMock = new Mock<IAutocompleteRepository>();

        public AutocompleteDomainTests()
        {
            _autocompleteDomain = new AutocompleteDomain(_autocompleteRepositoryMock.Object);
        }

        [Fact]
        public void CorrectAnswer_ShouldReturnStringWithAnswer_WhenAnswerIdWasFound()
        {
            var expectedAnswer = new GesTautocompletado() { Id = 1, Respuesta = "variable" };
            _autocompleteRepositoryMock.Setup(x => x.ReadOne(expectedAnswer.Id)).Returns(expectedAnswer);

            var actualAnswer = _autocompleteDomain.Get(1);

            Assert.NotNull(actualAnswer);
            Assert.NotEmpty(actualAnswer.Respuesta);
        }

    }
}
