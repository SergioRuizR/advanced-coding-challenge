using Application.Common.Behaviours;
using DaBulllet.TODO.API.Filters;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DaBulllet.TODO.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            //services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("Default")));
            services.AddMediatR(AppDomain.CurrentDomain.Load("Application"));
            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

            services.AddControllersWithViews(options =>
            options.Filters.Add<GlobalExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("Application"));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuditLogsBehavior<,>));


            services.AddAutoMapper(AppDomain.CurrentDomain.Load("Application"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            SeedProducts(app).Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public async Task SeedProducts(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.TodoItems.Any())
            {
                context.TodoItems.AddRange(new List<TodoItem>
                {
                    new TodoItem
                    {
                        Id = Guid.NewGuid(),
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
    }
}
