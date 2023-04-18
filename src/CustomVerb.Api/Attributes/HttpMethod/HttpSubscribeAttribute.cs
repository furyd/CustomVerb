using Microsoft.AspNetCore.Mvc.Routing;

namespace CustomVerb.Api.Attributes.HttpMethod;

public class HttpSubscribeAttribute : HttpMethodAttribute
{
    private static readonly IEnumerable<string> SupportedMethods = new[] { Constants.HttpExtensions.DLNA.Verbs.Subscribe };

    public HttpSubscribeAttribute() : base(SupportedMethods)
    {
    }

    public HttpSubscribeAttribute(string? template) : base(SupportedMethods, template)
    {
    }
}