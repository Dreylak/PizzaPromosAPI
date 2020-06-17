using System;
using Xunit;

namespace Application.UnitTests.SiteHandlers
{
    public class AddSiteHandlerTests
    {
        [Fact]
        public void ShouldAddSiteHandler()
        {
            //arrange
            var dbContext = new PizzaPromosDbContext();

            var useCase = new AddSiteHandlerUseCase(dbContext);

            var addSiteHandlerRequest = new AddSiteHandlerRequest();

            //action
            var siteHandlerId = useCase.Handle(addSiteHandlerRequest);

            //assert
            Assert.Equal(1, siteHandlerId);
        }
    }
}
