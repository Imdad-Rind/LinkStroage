using LinkStorage.Models;
using LinkStorage.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LinkStorage.Controllers;

public class AdminController : Controller
{
    private readonly RoleManager<Roles> _roleManager;

    public AdminController(RoleManager<Roles> roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult CreateRole()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var role = new Roles
            {
                Name = model.role
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("CreateRole");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }

        }
        return View(model);
    }

    
    
    
    
    
}