using System;
using Autofac;
using Library_API.Data;

namespace MatrixApi.Autofac
{
    static partial class Injection
    {
        private static void CreateClassMap(ContainerBuilder builder)
        {
            builder.RegisterType<DataStorage>().As<DataStorage>().SingleInstance();
        }
    }
}