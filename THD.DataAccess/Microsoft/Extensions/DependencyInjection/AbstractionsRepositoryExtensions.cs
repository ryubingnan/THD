using THD.DataAccess.Repositories.Abstract;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AbstractRepositoryExtensions
    {
        public static void AddCustomRepository<TRepository, TRepositoryImpl>(this IServiceCollection services)
            where TRepository : IRepository
            where TRepositoryImpl : IRepository
        {
            services.AddTransient(typeof(TRepository), typeof(TRepositoryImpl));
        }

        public static void AddDefaultRepository(
            this IServiceCollection services,
            Type entityType,
            Type repositoryImplementationType,
            bool replaceExisting = false)
        {
            //IReadonlyRepository<TEntity>
            var readOnlyRepositoryInterface = typeof(IReadonlyRepository<>).MakeGenericType(entityType);
            if (readOnlyRepositoryInterface.IsAssignableFrom(repositoryImplementationType))
            {
                RegisterService(services, readOnlyRepositoryInterface, repositoryImplementationType,
                    replaceExisting);

                //IBasicAdoRepository<TEntity>
                var basicAdoRepositoryInterface = typeof(IBasicAdoRepository<>).MakeGenericType(entityType);
                if (basicAdoRepositoryInterface.IsAssignableFrom(basicAdoRepositoryInterface))
                {
                    RegisterService(services, basicAdoRepositoryInterface, repositoryImplementationType,
                        replaceExisting);
                }

                //IBasicRepository<TEntity>
                var basicRepositoryInterface = typeof(IBasicRepository<>).MakeGenericType(entityType);
                if (basicRepositoryInterface.IsAssignableFrom(repositoryImplementationType))
                {
                    RegisterService(services, basicRepositoryInterface, repositoryImplementationType, replaceExisting);

                    //IRepository<TEntity>
                    var repositoryInterface = typeof(IRepository<>).MakeGenericType(entityType);
                    if (repositoryInterface.IsAssignableFrom(repositoryImplementationType))
                    {
                        RegisterService(services, repositoryInterface, repositoryImplementationType, replaceExisting);
                    }
                }
            }
        }

        private static void RegisterService(
            IServiceCollection services,
            Type serviceType,
            Type implementationType,
            bool replaceExisting)
        {
            if (replaceExisting)
            {
                services.Replace(ServiceDescriptor.Transient(serviceType, implementationType));
            }
            else
            {
                services.TryAddTransient(serviceType, implementationType);
            }
        }
    }
}