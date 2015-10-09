using Autofac;
using Project.Domain.Repositories;
using Project.Infrastructure.Repositories;

namespace Project.Kernel
{
    public class MiscModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CollectionRepository>()
                   .As<ICollectionRepository>()
                   .InstancePerRequest();
        }
    }
}