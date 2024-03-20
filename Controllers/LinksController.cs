using LinkStorage.Models;
using LinkStorage.Services;
using LinkStorage.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkStorage.Controllers;

[Authorize]
public class LinksController : Controller
{
    private readonly ILinkService _service;
    private readonly IApiService _apiService;
    private readonly UserManager<User> _userManager;

    public LinksController(ILinkService service, IApiService apiService, UserManager<User> userManager)
    {
        _apiService = apiService;
        _userManager = userManager;
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Home()
    {
        var u = await _userManager.GetUserAsync(User);
        Guid.TryParse(u.Id ,out Guid uId);
        
        var links = await _service.AllTheLinksByUserId(uId);
        return View(links);
    }

    [HttpGet]
    [AllowAnonymous]
    /*
     * view all the public links or embed links
     */
    public async Task<IActionResult> Explore()
    {
        var content = await _service.GetPublicLinks();
        return View(content);
    }

    /*[HttpGet]
    public async Task<IActionResult> Detail(Guid? id)
    {
        var lnk = await _service.GetLinkById(id);
        

        return View();

    }*/

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LinksCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            var u = await _userManager.GetUserAsync(User);
            var lnk = new Links
            {
                Link = model.Link,
                Site = model.Site,
                IsPublic = model.IsPublic,
                User = u,
                
                
            };
            lnk.User.Id = u.Id;
            if (lnk.IsPublic)
            {
                lnk.User.PublicPostCount++;
            }

            if (await _service.GetHtmlIfExist(model.Link) != null )
            {
                lnk.RawHtml = await _service.GetHtmlIfExist(model.Link);
            }
            else
            {
                var content = await _apiService.EmbededContent(model.Link);
                lnk.RawHtml = content.html;
            }
            
            await _service.CreateNewLink(lnk);
            return RedirectToAction("Home");
        }
        
        return View(model);
    }
}