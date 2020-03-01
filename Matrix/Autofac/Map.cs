using System;
using Autofac;
using MatrixApi.Generator;
using MatrixApi.Model;
using MatrixApi.Store;

namespace MatrixApi.Autofac
{
    static partial class Injection
    {
        private static void CreateClassMap(ContainerBuilder builder)
        {
            builder.RegisterType<MatrixGenerator>().As<IMatrixGenerator>();
            builder.RegisterType<Matrix>().As<IMatrix>();
            builder.RegisterType<MatrixStore>().As<IMatrixStore>();
        }
    }
}
