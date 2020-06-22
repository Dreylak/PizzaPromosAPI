using Application.SiteHandlers.AddSiteHandler;
using Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SiteHandlers
{
    public class AddSiteHandlerTests : TestBase
    {
        [Fact]
        public async Task ShouldAddSiteHandler()
        {
            //arrange
            var useCase = new AddSiteHandlerUseCase(DbContext);

            var addSiteHandlerRequest = new AddSiteHandlerRequest()
            {
                SiteName = "Test",
                SiteUrl = "test.com",
                HandlerUrl = "testhandler.com"
            };

            //action
            var siteHandlerId = useCase.Handle(addSiteHandlerRequest);

            SiteHandler siteHandler = await DbContext.SiteHandlers.SingleAsync(x => x.Id == 1);

            //assert
            siteHandler.Should().NotBe(null);

            siteHandler.Id.Should().Be(1);
            siteHandler.SiteName.Should().Be("Test");
            siteHandler.SiteUrl.Should().Be("test.com");
            siteHandler.HandlerUrl.Should().Be("testhandler.com");
        }
    }
}
