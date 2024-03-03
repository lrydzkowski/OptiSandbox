using EPiServer.DataAccess;
using EPiServer.Security;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Models.Pages;

namespace OptiSandbox.Controllers.Api;

[ApiController]
[Route("api/pages")]
public class PagesController : ControllerBase
{
    private readonly IContentRepository _contentRepository;

    public PagesController(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    [HttpPost]
    public IActionResult CreatePage()
    {
        PageReference parent = ContentReference.StartPage;
        AboutPage newAboutPage = _contentRepository.GetDefault<AboutPage>(parent);
        newAboutPage.Name = "Test Name 1";
        newAboutPage.MainTitle = "Test Name 1";
        newAboutPage.Content = new XhtmlString("<h1>Test H1 element in the content</h1>");
        ContentReference createdPage = _contentRepository.Save(newAboutPage, SaveAction.Publish, AccessLevel.NoAccess);

        return Ok(createdPage);
    }
}
