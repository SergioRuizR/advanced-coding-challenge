using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Respawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da.Bullet.TODO.API.IntegrationTests
{
    public class TestBase
    {
        protected ApiWebApplicationFactory _application;

        [TearDown]
        public async Task Down()
        {
            await ResetState();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _application.Dispose();
        }

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            _application = new ApiWebApplicationFactory();

            EnsureDatabase();
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _application.Services.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

            return await mediator.Send(request);
        }

        protected async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            using var scope = _application.Services.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Add(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        private void EnsureDatabase()
        {
            using var scope = _application.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();
        }

        private async Task ResetState()
        {
            using var scope = _application.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            if (context.Database.IsSqlite())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            //else if (context.Database.IsSqlServer())
            //{
            //    var checkpoint = new Checkpoint
            //    {
            //        TablesToIgnore = new[] { "__EFMigrationsHistory" }
            //    };
            //    var config = scope.ServiceProvider.GetService<IConfiguration>();

            //    await checkpoint.Reset(config.GetConnectionString("Default"));

            //}

            await SeedDataAsync(context);
        }

        public static async Task SeedDataAsync(ApplicationDbContext context)
        {

            if (!context.TodoItems.Any())
            {
                context.TodoItems.AddRange(new List<TodoItem>
                {
                    new TodoItem
                    {
                        Id = Guid.Parse("4cb3368c-2933-4b79-9b74-a959a5a4fdac"),
                        Title = "New device service",
                        Description = "Create new service to manage warehouse devices"
                    },
                    new TodoItem
                    {
                        Id = Guid.NewGuid(),
                        Title = "Carry out training",
                        Description = "Arrange meeting to train my team"
                    },
                    new TodoItem
                    {
                       Id = Guid.NewGuid(),
                        Title = "Take some rest",
                        Description = "🙂"
                    }
                }); ;

                await context.SaveChangesAsync();
            }
        }

        public HttpClient CreateTestClient()
        {
            return _application.CreateClient();
        }
    }
}
