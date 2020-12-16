using Microsoft.Extensions.DependencyInjection;
using System;

namespace Abc.Domain.Common {

    public static class GetRepository {

        internal static IServiceProvider services;
        public static void SetServiceProvider(IServiceProvider provider) => services = provider;

        public static T Instance<T>() => instance<T>(services);

        public static object Instance(Type t) => instance(services, t);


        internal static T instance<T>(IServiceProvider h) {
            if (h is null) return default;
            var i = h.GetRequiredService<T>();
            return i;
        }

        internal static object instance(IServiceProvider h, Type t) {
            var i = h?.GetRequiredService(t);
            return i;
        }

    }

}
