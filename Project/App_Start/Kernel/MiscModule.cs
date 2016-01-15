using Autofac;
using Project.Domain.Application;
using Project.Infrastructure.Application;

namespace Project.Kernel
{
    public class MiscModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextService>()
                   .As<IHttpContextService>()
                   .InstancePerRequest();
        }
    }
}