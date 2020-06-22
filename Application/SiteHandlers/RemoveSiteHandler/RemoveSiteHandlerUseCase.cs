using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.SiteHandlers.RemoveSiteHandler
{
    public class RemoveSiteHandlerUseCase : IUseCase<int, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public RemoveSiteHandlerUseCase(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(int id)
        {
            var entity = await _dbContext.SiteHandlers.FindAsync(id);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(SiteHandler), id);
            }

            _dbContext.SiteHandlers.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
