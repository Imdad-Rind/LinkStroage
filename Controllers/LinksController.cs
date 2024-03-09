using LinkStorage.Models;
using LinkStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkStorage.Controllers;

public class LinksController : Controller
{
    private readonly ILinkService _service;
    private readonly IApiService _apiService;

    public LinksController(ILinkService service, IApiService apiService)
    {
        _apiService = apiService;
       _service = service;
    }

    public async Task<IActionResult> Home()
    {
        var links = await _service.GetAllTheLinks();
        return View(links);
    }

    [HttpGet]
    public async Task<IActionResult> Detail(Guid? id)
    {
        var lnk = await _service.GetLinkById(id);
        

        return View();

    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Links obj)
    {
        if (ModelState.IsValid)
        {
            var content = await _apiService.EmbededContent(obj.Link);
            obj.RawHtml = content.html;
            
            await _service.CreateNewLink(obj);
            return RedirectToAction("Home");
        }
        return View(obj);
    }
}