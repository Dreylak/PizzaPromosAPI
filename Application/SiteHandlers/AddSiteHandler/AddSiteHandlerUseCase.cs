using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.SiteHandlers.AddSiteHandler
{
    public class AddSiteHandlerUseCase : IUseCase<AddSiteHandlerRequest, int>
    {
        private readonly IApplicationDbContext _dbContext;
        public AddSiteHandlerUseCase(IApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<int> Handle(AddSiteHandlerRequest request)
        {
            var entity = new SiteHandler
            {
                SiteName = request.SiteName,
                SiteUrl = request.SiteUrl,
                HandlerUrl = request.HandlerUrl
            };

            _dbContext.SiteHandlers.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }
    }
}
