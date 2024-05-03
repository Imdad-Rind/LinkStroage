using LinkStorage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LinkStorage.Models;
using LinkStorage.Services;
using Microsoft.AspNetCore.Identity;

namespace LinkStorage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILinkService _linkService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public HomeController(ILogger<HomeController> logger, 
            ILinkService linkService, UserManager<User> 
                userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _linkService = linkService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        { 
             if (_signInManager.IsSignedIn(User))
            {
                var currentUserId = _userManager.GetUserId(User);
                Guid guidCurrentUserId = Guid.Parse(currentUserId);
                
                var lnks = await _linkService.GetAllThePublicLinksOfUserYouFollowingByYourId(guidCurrentUserId);
                return View(lnks);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
