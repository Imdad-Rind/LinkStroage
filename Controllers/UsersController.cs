using LinkStorage.Models;
using LinkStorage.Services;
using LinkStorage.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkStorage.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ILinkService _linkService;
    private readonly IFollowerService _followerService;

    public UsersController(UserManager<User> userManager, ILinkService linkService, IFollowerService followerService)
    {
        _userManager = userManager;
        _linkService = linkService;
        _followerService = followerService;
    }

    [HttpGet]
    public async Task<ActionResult> Profile(Guid? id, ProfileViewModel model)
    {
            var u = await _userManager.FindByIdAsync(id.ToString());
            var lnk = await _linkService.GetAllPublicLinksById(id);

            if (User.Identity.IsAuthenticated)
            {

                var CurrentUser = await _userManager.GetUserAsync(User);
                Guid CurrentUserGuidId = Guid.Parse(CurrentUser.Id);

                if (await _followerService.IsFollowing(CurrentUserGuidId, id))
                {
                    model.IsFollowing = true;
                }
                else
                {
                    model.IsFollowing = false;
                }

            }

            model.User = u;
            model.links = lnk;

            return View(model);

        
    }
}