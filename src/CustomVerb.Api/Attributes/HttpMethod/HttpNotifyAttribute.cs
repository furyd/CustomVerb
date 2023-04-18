using Microsoft.AspNetCore.Mvc.Routing;

namespace CustomVerb.Api.Attributes.HttpMethod;

public class HttpNotifyAttribute : HttpMethodAttribute
{
    private static readonly IEnumerable<string> SupportedMethods = new[] { Constants.HttpExtensions.DLNA.Verbs.Notify };

    public HttpNotifyAttribute() : base(SupportedMethods)
    {
    }

    public HttpNotifyAttribute(string? template) : base(SupportedMethods, template)
    {
    }
}