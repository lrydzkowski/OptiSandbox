using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using OptiSandbox.Business;
using OptiSandbox.Business.Rendering;

namespace OptiSandbox;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;

    public Startup(IWebHostEnvironment webHostingEnvironment)
    {
        _webHostingEnvironment = webHostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData(
                "DataDirectory",
                Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data")
            );

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        services.Configure<RazorViewEngineOptions>(
            options => options.ViewLocationExpanders.Add(new SiteViewEngineLocationExpander())
        );

        services
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCms()
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>();
        services.Configure<MvcOptions>(options => options.Filters.Add<PageContextActionFilter>());

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapContent();
                endpoints.MapControllers();
            }
        );
    }
}
