using EmployeeService.Constants;
using EmployeeService.Models;
using EmployeeService.Repositories;
using EmployeeService.Repositories.Abstractions;
using EmployeeService.Services;
using EmployeeService.Services.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeService
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
            services.AddControllers().AddNewtonsoftJson();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowCorsPolicy",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin();
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();
                                  });
            });

            var connectionString = this.Configuration.GetValue<string>(ConfigurationConstants.DBConnectionString);
            services.AddDbContext<EmployeeDBContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IEmployeeRepository, EmployeeRepository<EmployeeDBContext>>();
            services.AddTransient<IEmploymentTypeRepository, EmploymentTypeRepository<EmployeeDBContext>>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository<EmployeeDBContext>>();
            services.AddTransient<IDesignationRepository, DesignationRepository<EmployeeDBContext>>();

            services.AddTransient<IEmployeeService, Services.EmployeeService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowCorsPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
