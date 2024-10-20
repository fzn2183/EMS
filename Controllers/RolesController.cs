using EmployeeManagment.Data;
using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Controllers
{
    public class RolesController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;


        public RolesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        public async Task<ActionResult> Index()
        {

            var roles = await _context.Roles.ToListAsync();
            return View(roles);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();


        }
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            IdentityRole role = new IdentityRole();
            role.Name = model.RoleName;
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }


        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var role = new RoleViewModel();

            var result = await _roleManager.FindByIdAsync(id);
            role.RoleName = result.Name; ;
            role.Id = result.Id;
            return View(role);


        }

        [HttpPost]
        public async Task<ActionResult> Edit(string Id, RoleViewModel model)
        {
            var check = await _roleManager.RoleExistsAsync(model.RoleName);
            if (!check)
            {

                 
                var result = await _roleManager.FindByIdAsync(Id);
                result.Name = model.RoleName;
                var finalresult = await _roleManager.UpdateAsync(result);
                if (finalresult.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(model);
                }

            }
            return View(model);
        }
    }
}
