using EmployeeManagementFSApiBackend.Dal;
using EmployeeManagementFSApiBackend.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagementFSApiBackend
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(_Configuration.GetConnectionString("EmployeeManagementdb"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("EmployeeApi", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("POST");
                });

            });
            services.AddScoped<DbContext, AppDbContext>();
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("EmployeeApi");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Api v1");
            });


        }
    }
}
