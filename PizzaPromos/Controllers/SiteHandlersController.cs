using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.SiteHandlers.AddSiteHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteHandlersController : ControllerBase
    {
        private readonly AddSiteHandlerUseCase _addSiteHandlerUseCase;

        public SiteHandlersController(AddSiteHandlerUseCase addSiteHandlerUseCase)
        {
            _addSiteHandlerUseCase = addSiteHandlerUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(AddSiteHandlerRequest request)
        {
            return await _addSiteHandlerUseCase.Handle(request);
        }
    }
}