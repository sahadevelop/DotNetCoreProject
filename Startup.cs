using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace TMIDotNetCoreFinalProject
{
    public class Startup : object
    {
        public Startup() : base()
        {
        }

		public void ConfigureServices(IServiceCollection services)
		{
			//با افزودن این سرویس سایر قابلیت ها ام وی سی شامل کنترلر و ویو و ... نیز افزوده میشود 
			services.AddControllers();

			//افزودن Swagger Register the Swagger generator
			services.AddSwaggerGen();

		}


		// ازین تابع برای گوش دادن به درخواست ها و اجرای دستورات RunTime استفاده میکنیم.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();
			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				//برای نمایش صفحه Swagger به عنوان صفحه پیش فرض
				c.RoutePrefix = string.Empty;
			});
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();

			});


		}
	}
}
