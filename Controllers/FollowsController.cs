using LinkStorage.Models;
using LinkStorage.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkStorage.Controllers;

public class FollowsController : Controller
{
    private readonly IFollowerService _followerService;
    private readonly UserManager<User> _userManager;

    public FollowsController(IFollowerService followerService, 
        UserManager<User> userManager)
    {
        _followerService = followerService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> FollowUser(Guid id)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }

        var targetId = id;
        
        var currentUser = await _userManager.GetUserAsync(User);
        var targetUser = await _userManager.FindByIdAsync(targetId.ToString());
        Guid currentUserIDGuid = Guid.Parse(currentUser.Id);

        try
        {
            targetUser.FollowersCount++;
            currentUser.FollowingsCount++;
            
            await _followerService.FollowNewUser(currentUserIDGuid, targetId);
            
            
            return RedirectToAction("Profile", "Users", new { id = targetId });
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "An error occurred while following the user.");
            return RedirectToAction("Profile", "Users", new { id = targetId });
        }
        
        
    }
    
    [HttpGet]
    public async Task<IActionResult> UnFollow(Guid id)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }

        var targetId = id;
        
        var currentUser = await _userManager.GetUserAsync(User);
        var targetUser = await _userManager.FindByIdAsync(targetId.ToString());
        Guid currentUserIDGuid = Guid.Parse(currentUser.Id);

        try
        {
            if (await _followerService.IsFollowing(currentUserIDGuid, targetId))
            {
                targetUser.FollowersCount--;
                currentUser.FollowingsCount--;
            
                await _followerService.UnFollow(currentUserIDGuid, targetId);
            
            
                return RedirectToAction("Profile", "Users", new { id = targetId });
            }
            
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "An error occurred while Unfollowing the user.");
            return RedirectToAction("Profile", "Users", new { id = targetId });
        }
        
        return RedirectToAction("Profile", "Users", new { id = targetId });
    }
    
}