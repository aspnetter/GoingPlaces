using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Web.DbContext
{
    public class DesignTimeDbContextFactory<T> : IDesignTimeDbContextFactory<T> where T:Microsoft.EntityFrameworkCore.DbContext, new()
    {
        private const string ConnectionStringName = "GoingPlaces";

        public T CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<T>();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            builder.UseSqlServer(connectionString);

            var contextType = typeof(T);
            var constructor = contextType.GetConstructor(new[] { typeof(DbContextOptions<T>) });
                
            //var dbContext = (T)Activator.CreateInstance(
            //    contextType,
            //    BindingFlags.Public | BindingFlags.Instance,
            //    null,
            //    new []{ builder.Options }
            //    );

            //return dbContext;
            return (T)constructor.Invoke(new object[] {builder.Options});
        }
    }
}
