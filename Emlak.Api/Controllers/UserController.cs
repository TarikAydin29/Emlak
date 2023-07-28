using Emlak.DAL.Abstract;
using Emlak.DTO.UserDTOs;
using Emlak.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Emlak.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IAgentService agentService;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IAgentService agentService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.agentService = agentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterDTO dto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = dto.Username,
                    Email = dto.Email,
                    Name = dto.Name,
                    Surname = dto.Surname,
                    PhoneNumber = dto.PhoneNumber,
                    ImageUrl = dto.ImageUrl!,
                };

                IdentityResult result = await userManager.CreateAsync(appUser, dto.Password);
                if (result.Succeeded)
                {
                    Agent agent = new Agent()
                    {
                        Name = dto.Name,
                        Surname = dto.Surname,
                        Phonenumber = dto.PhoneNumber,
                        Email = dto.Email,
                        ImageUrl = dto.ImageUrl!
                    };
                    agentService.Add(agent);
                    return Ok(dto);
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                return BadRequest(result.Errors);


            }
            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new AppRole() { Name = name });
                if (result.Succeeded)
                {
                    return Ok(name);
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                return BadRequest(result.Errors);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await signInManager.PasswordSignInAsync(dto.Username, dto.Password, true, true);
            var user = await userManager.FindByNameAsync(dto.Username);
            
            if (result.Succeeded)
            {
                return Ok(user.Name);
            }
            return BadRequest();
        }



    }
}
