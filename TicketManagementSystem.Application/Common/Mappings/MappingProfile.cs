using AutoMapper;
using System.Reflection;

namespace TicketManagementSystem.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingFromAssemply(Assembly.GetExecutingAssembly());
        }
        private void ApplyMappingFromAssemply(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom<>);

            var mappingMethodName = nameof(IMapFrom<object>.Mapping);

            bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;

            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

            var argumentTypes = new Type[] { typeof(Profile) };
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var interfaces = type.GetInterfaces().Where(HasInterface).ToList();
                if (interfaces.Count > 0)
                {
                    foreach (var iface in interfaces)
                    {
                        var interfaceMethodInfo = iface.GetMethod(mappingMethodName, argumentTypes);
                        interfaceMethodInfo?.Invoke(instance, new object[] { this });
                    }
                }

            }
        }
    }
}
