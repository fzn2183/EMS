using EmployeeManagment.Data;
using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeManagment.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {  private readonly UserManager<ApplicationUser> _userManager;
       private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
          
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;


            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            
            var users = await _context.Users.Include(x =>x.Role).ToListAsync();
              return View(users);

        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();

        }
        [HttpPost]
        public async Task<ActionResult>Create(UserViewModel userViewModel)
        {
            ApplicationUser users = new ApplicationUser();
            users.UserName = userViewModel.UserName;
            users.FirstName = userViewModel.FirstName;
            users.MiddleName = userViewModel.MiddleName;
            users.LastName = userViewModel.LastName;
            users.NationalId = userViewModel.NationalId;
            users.UserName = userViewModel.UserName;
            users.NormalizedUserName = userViewModel.UserName; 
            users.Email = userViewModel.Email;
            users.EmailConfirmed = true;
            users.PhoneNumber = userViewModel.PhoneNumber;
            users.CreatedOn = DateTime.Now;
            users.CreatedById = "Mohd Faizaan";
            users.RoleId = userViewModel.RoleId;
            //users.PhoneNumberConfirmed = false;
             

             var result = await _userManager.CreateAsync(users,userViewModel.Password);
            if (result.Succeeded) {

                return RedirectToAction("Index");
            }
            else
            { 
                return View(userViewModel);

            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name",userViewModel.RoleId);
        }

        
    }
}
