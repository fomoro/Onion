
using Miles.Booking.Application;

namespace Miles.Booking.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }       

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<ICoursesProvider, FakeCoursesProvider>();
            services.AddAplicationLayer();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
