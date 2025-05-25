using Castle.DynamicProxy;
using System.Reflection;

namespace ECommerce.Application
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptor>(true).ToList();
            var parameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();
            var genericCount = method.IsGenericMethod ? method.GetGenericArguments().Length : 0;

            var targetMethod = type.GetMethods()
                .FirstOrDefault(m => m.Name == method.Name
                    && m.GetGenericArguments().Length == genericCount
                    && m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes));

            if (targetMethod != null)
            {
                var methodAttributes = targetMethod.GetCustomAttributes<MethodInterceptor>(true);
                classAttributes.AddRange(methodAttributes);
            }

            return classAttributes.ToArray();
        }
    }
}
