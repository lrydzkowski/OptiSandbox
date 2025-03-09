using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Commerce.FindSearchProvider;
using EPiServer.Scheduler;
using EPiServer.Web.Routing;
using Mediachase.Commerce.Anonymous;
using OptiSandbox.Web.Content;

namespace OptiSandbox.Web;

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

        services
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCommerce()
            .AddFind()
            .AddFindSearchProvider()
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>()
            .AddContentModule();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAnonymousId();

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapContent(); });
    }
}
