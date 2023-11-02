using Autofac;

namespace DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                  .Where(i => i.Name.EndsWith("Repository") && i.IsClass)
                  .AsImplementedInterfaces()
                  .InstancePerDependency();
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                  .Where(i => i.Name.EndsWith("Service") && i.IsClass)
                  .AsImplementedInterfaces()
                  .InstancePerDependency();
        }
    }
}
