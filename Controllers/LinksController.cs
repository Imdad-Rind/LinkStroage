using LinkStorage.Models;
using LinkStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkStorage.Controllers;

public class LinksController : Controller
{
    private readonly ILinkService _service;

    public LinksController(ILinkService service)
    {
       _service = service;
    }

    public async Task<IActionResult> Home()
    {
        var links = await _service.GetAllTheLinks();
        return View(links);
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
            await _service.CreateNewLink(obj);
            return RedirectToAction("Home");
        }
        return View(obj);
    }
}