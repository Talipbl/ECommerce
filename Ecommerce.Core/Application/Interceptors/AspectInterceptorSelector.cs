using Castle.DynamicProxy;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Application.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptor>(true).ToList();
            List<Type> types = new List<Type>();
            method.GetParameters().ToList().ForEach(x => types.Add(x.ParameterType));
            var generic = method.GetGenericArguments().Count();
            var arrayTypes = types.ToArray();
            var methodAttributes = type.GetMethod(method.Name, generic, arrayTypes).GetCustomAttributes<MethodInterceptor>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.ToArray();
        }
    }
}
