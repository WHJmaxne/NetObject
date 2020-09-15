using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _03CatDI
{
    public class Cat
    {
        private ConcurrentDictionary<Type, Type> typeMapping = new ConcurrentDictionary<Type, Type>();

        public Cat Register<TFrom, TTo>() where TFrom : class where TTo : class
        {
            typeMapping[typeof(TFrom)] = typeof(TTo);
            return this;
        }
        public TFrom GetService<TFrom>() where TFrom : class
        {
            var service = GetService(typeof(TFrom));
            return service as TFrom;
        }

        public object GetService(Type serviceType)
        {
            if (!typeMapping.TryGetValue(serviceType, out Type type))
            {
                type = serviceType;
            }

            if (type.IsInterface || type.IsAbstract)
            {
                return null;
            }

            ConstructorInfo constructor = GetConstructor(type);
            if (constructor == null)
            {
                return null;
            }

            var arguments = constructor.GetParameters().Select(p => this.GetService(p.ParameterType)).ToArray();
            object service = constructor.Invoke(arguments);
            this.InitializeInjectedProperties(service);
            this.InvokeInjectMethods(service);
            return service;
        }

        protected virtual ConstructorInfo GetConstructor(Type type)
        {
            var constructors = type.GetConstructors();
            return constructors.FirstOrDefault(c => c.GetCustomAttribute<InjectionAttribute>() != null) ?? constructors.FirstOrDefault();
        }

        protected virtual void InitializeInjectedProperties(object service)
        {
            PropertyInfo[] properties = service.GetType().GetProperties().Where(d => d.GetCustomAttribute<InjectionAttribute>() != null).ToArray();
            Array.ForEach(properties, p =>
            {
                p.SetValue(service, GetService(p.PropertyType));
            });
        }

        protected virtual void InvokeInjectMethods(object service)
        {
            MethodInfo[] methods = service.GetType().GetMethods().Where(d => d.GetCustomAttribute<InjectionAttribute>() != null).ToArray();
            Array.ForEach(methods, m =>
            {
                var arguments = m.GetParameters().Select(p => this.GetService(p.ParameterType)).ToArray();
                m.Invoke(service, arguments);
            });
        }
    }
}
