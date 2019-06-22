using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAutomate
{
	public class Startup
	{
		#region Private fields

		private const string DataDirectoryKey = "DataDirectory";

		#endregion

		#region Public methods

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<AppDbContext>(options =>
			{
				var dataDirectoryPath = GetDataDirectoryPath();
				var connectionString = Configuration.GetConnectionString("AppDbContext")
					.Replace($"|{DataDirectoryKey}|", dataDirectoryPath);
				
				options.UseSqlServer(connectionString);
			});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			var baseDir = env.ContentRootPath;

			AppDomain.CurrentDomain.SetData(DataDirectoryKey, Path.Combine(baseDir, "App_Data"));

			try
			{
				using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
				{
					var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
					context.Database.Migrate();
				}
			}
			catch (Exception ex)
			{

			}
		}

		#endregion

		#region Private methods

		private string GetDataDirectoryPath()
		{
			var path = AppDomain.CurrentDomain.GetData(DataDirectoryKey) as string;

			return path ?? ".\\App_Data";
		}

		#endregion
	}
}
