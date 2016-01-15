using System.Collections.Specialized;
using System.Web;
using Project.Domain.Application;

namespace Project.Infrastructure.Application
{
    public class HttpContextService : IHttpContextService
    {
        public HttpContextBase Context => new HttpContextWrapper(HttpContext.Current);

        public HttpRequestBase Request => Context.Request;

        public HttpResponseBase Response => Context.Response;

        public NameValueCollection FormOrQuerystring => Request.RequestType == "POST" ? Request.Form : Request.QueryString;
    }
}
