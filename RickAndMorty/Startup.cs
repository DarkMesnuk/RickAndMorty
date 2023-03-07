using Microsoft.OpenApi.Models;
using RickAndMorty.Service;
using RickAndMorty.Repository;
using RickAndMorty.Services.Interface;
using RickAndMorty.Repository.Interface;
using RickAndMorty.Configs;
using Microsoft.Extensions.Caching.Memory;

namespace RickAndMorty
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
			services.AddHttpClient<IRickAndMortyRepository, RickAndMortyRepository>();

            services.AddScoped<IRickAndMortyRepository, RickAndMortyRepository>();
            services.AddScoped<IRickAndMortyService, RickAndMortyService>();

			APIUrlConfig.RickAndMortyAPI = Configuration["ServiceUrls:RickAndMortyAPI"];

            services.AddSingleton(MappingConfig.RegisterMaps().CreateMapper());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMemoryCache();

            services.AddControllers();

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "RickAndMorty", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RickAndMorty v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
