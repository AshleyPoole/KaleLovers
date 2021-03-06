﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KaleLovers
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			// Set up configuration sources.
			var builder = new ConfigurationBuilder();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");

				//// For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
				//try
				//{
				//    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
				//        .CreateScope())
				//    {
				//        serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
				//             .Database.Migrate();
				//    }
				//}
				//catch { }
			}

			app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

			app.UseStaticFiles();

			//app.UseIdentity();

			// To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		// Entry point for the application.
		public static void Main(string[] args) => WebApplication.Run<Startup>(args);
	}
}
