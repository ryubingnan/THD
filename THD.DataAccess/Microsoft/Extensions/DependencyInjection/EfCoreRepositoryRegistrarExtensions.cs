using THD.DataAccess.DbContexts;
using THD.DataAccess.Models.Abstract;
using THD.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EfCoreRepositoryRegistrarExtensions
    {
        /// <summary>
        /// 为所有实体注入默认EF仓储
        /// </summary>
        public static void AddDefaultRepositories<TDbContext>(this IServiceCollection services)
            where TDbContext : EfCoreDbContext<TDbContext>
        {
            var entityTypes = GetEntityTypes(typeof(TDbContext));
            var dbContextType = typeof(TDbContext);

            foreach (Type entityType in entityTypes)
            {
                var repositoryImplementationType = GetRepositoryType(dbContextType, entityType);

                services.AddDefaultRepository(entityType, repositoryImplementationType, true);
            }
        }

        private static IEnumerable<Type> GetEntityTypes(Type dbContextType)
        {
            return
                from property in dbContextType.GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                where
                    IsAssignableToGenericType(property.PropertyType, typeof(DbSet<>)) &&
                    typeof(IEntity).IsAssignableFrom(property.PropertyType.GenericTypeArguments[0])
                select property.PropertyType.GenericTypeArguments[0];
        }

        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var givenTypeInfo = givenType.GetTypeInfo();

            if (givenTypeInfo.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            foreach (var interfaceType in givenTypeInfo.GetInterfaces())
            {
                if (interfaceType.GetTypeInfo().IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
            }

            if (givenTypeInfo.BaseType == null)
            {
                return false;
            }

            return IsAssignableToGenericType(givenTypeInfo.BaseType, genericType);
        }

        private static Type GetRepositoryType(Type dbContextType, Type entityType)
        {
            return typeof(EfCoreRepository<,>).MakeGenericType(dbContextType, entityType);
        }
    }
}