using CleanArchitectureWebAPI.WebAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitectureWebAPI.WebAPI.Controllers
{
    [Route( "api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<IdentityUser>> Register(RegisterViewModel model)
        {
            IdentityUser user = new()
            {
                Email = model.Email
            };

            IdentityResult userResult = await _userManager.CreateAsync(user, model.Password);

            if (userResult.Succeeded)
            {
                bool roleExists = await _roleManager.RoleExistsAsync("User");
                if (!roleExists)
                {
                    await AddRole("User");
                }

                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    return user;
                }

                foreach (var error in userResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }

            foreach (var error in userResult.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState.Values);
        }

        private async Task<IdentityResult> AddRole(string roleName)
        {
            var role = new IdentityRole
            {
                Name = roleName
            };
            return await _roleManager.CreateAsync(role);
        }


    }
}
