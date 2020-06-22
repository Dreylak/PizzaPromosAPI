using Application.Exceptions;
using Application.SiteHandlers.RemoveSiteHandler;
using Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.SiteHandlers
{
    public class RemoveSiteHandlerTests : TestBase
    {
        private readonly RemoveSiteHandlerUseCase _useCase;

        public RemoveSiteHandlerTests()
        {
            _useCase = new RemoveSiteHandlerUseCase(DbContext);

            //seed test data
            DbContext.SiteHandlers.Add(new SiteHandler());
            DbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task ShouldThrowNotFoundException()
        {
            int id = 2;

            FluentActions.Invoking(() => _useCase.Handle(id))
                .Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task ShouldRemoveSiteHandler()
        {
            int id = 1;

            var result = await _useCase.Handle(id);

            SiteHandler siteHandler = await DbContext.SiteHandlers.SingleOrDefaultAsync(x => x.Id == id);
            
            result.Should().Be(true);

            siteHandler.Should().BeNull();
        }
    }
}
