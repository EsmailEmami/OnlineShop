using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineShop.Common.Exceptions;
using OnlineShop.Data.Core;
using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.User;
using OnlineShop.Infrastructure.Configurations;
using OnlineShop.Infrastructure.EFCoreConfig;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Infrastructure.Context
{
    public class OnlineShopDbContext : DbContext, IUnitOfWork
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options)
        {

        }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

        public new void Update<TEntity>(TEntity entity) where TEntity : class => Context.Update(entity);
        public new void Remove<TEntity>(TEntity entity) where TEntity : class => Context.Remove(entity);
        public new void Add<TEntity>(TEntity entity) where TEntity : class => Context.Add(entity);

        public List<string> SaveAllChanges(bool throwOnError = true)
        {
            var entities = from entry in ChangeTracker.Entries()
                           where entry.State is EntityState.Modified or EntityState.Added
                           select entry.Entity;

            List<string> errors = new();
            List<ValidationResult> validationResults = new();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    errors.AddRange(validationResults.Select(x => x.ErrorMessage).ToList()!);
                }
            }

            if (errors.Any())
            {
                if (throwOnError)
                    throw new DatabaseException(string.Join(", ", errors));

                return errors;
            }
            try
            {
                base.SaveChanges();
                return new List<string>();
            }
            catch (Exception e)
            {
                if (throwOnError)
                    throw new DatabaseException(e.Message);

                return new List<string> { e.Message };
            }
        }

        public void AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class =>
            Context.AddRange(entities);

        public void RemoveRange<TEntity>(IEnumerable<TEntity> removeList) where TEntity : class =>
            Context.RemoveRange(removeList);

        public new Database Database => Database;
        public DbContext Context => this;
        public HttpContext CurrentHttpContext => CurrentHttpContext;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Entity>().HasQueryFilter(x => !x.Deleted);
            //modelBuilder.Entity<Entity<int>>().HasQueryFilter(x => !x.Deleted);
            //modelBuilder.Entity<Entity<long>>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.RegisterAllEntities(typeof(User).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
