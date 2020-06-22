using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.SiteHandlers.AddSiteHandler
{
    public class AddSiteHandlerRequestValidator : AbstractValidator<AddSiteHandlerRequest>
    {
        public AddSiteHandlerRequestValidator()
        {
            string urlRegExp = @"(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";
            
            RuleFor(r => r.SiteName)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(r => r.SiteUrl)
                .NotEmpty()
                .Matches(urlRegExp);

            RuleFor(r => r.HandlerUrl)
                .NotEmpty()
                .Matches(urlRegExp);
        }
    }
}
