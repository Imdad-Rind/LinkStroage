using LinkStorage.Models;
using LinkStorage.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkStorage.Controllers;

public class AdminController : Controller
{
    private readonly RoleManager<Roles> _roleManager;
    private readonly UserManager<User> _userManager;

    public AdminController(RoleManager<Roles> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    
    [HttpGet]
    public IActionResult ListUsers()
    {
        var usersList = _userManager.Users.Select(u => new ListUserViewModel()
        {
            UserName = u.UserName,
            Email = u.Email,
            Followings = u.FollowingsCount,
            Followers = u.FollowersCount,
            PublicPost = u.PublicPostCount,
            // Roles = string.Join(" ", _userManager.GetRolesAsync(u).Result.ToList())
        }).ToList();
        return View(usersList);
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