﻿using EmployeeManagment.Data;
using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;

namespace EmployeeManagment.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var tasks = new ProfileViewModel();
            var roles = await _context.Roles.OrderBy(x => x.NormalizedName).ToListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "NormalizedName");

            var systemtasks = await _context.SystemProfiles
               .Include("Children.Children.Children")
               .OrderBy(x => x.Order)
               .ToListAsync();

            ViewBag.Tasks = new SelectList(systemtasks, "Id", "Name");

            return View(tasks);
        }

        public async Task<ActionResult> AssignRights(ProfileViewModel vm)
        {
            var Userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = new RoleProfile
            {
                TaskId = vm.TaskId,
                RoleId = vm.RoleId,
            };

            _context.RoleProfiles.Add(role);
            await _context.SaveChangesAsync(Userid);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> UserRights(string id)
        {
            var tasks = new ProfileViewModel();
            tasks.RoleId = id;
            tasks.Profiles = await _context.SystemProfiles
               .Include(s => s.Profile)
               .Include("Children.Children.Children")
               .OrderBy(x => x.Order)
               .ToListAsync();


            tasks.RolesRightsIds = await _context.RoleProfiles.Where(x => x.RoleId == id).Select(r => r.TaskId).ToListAsync();


            return View(tasks);
        }

        [HttpPost]
        public async Task<ActionResult> UserGroupRigths(string id, ProfileViewModel vm)
        {
            var Userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allrights= await _context.RoleProfiles.Where(x => x.RoleId == id).ToListAsync();
            _context.RoleProfiles.RemoveRange(allrights);
            await _context.SaveChangesAsync(Userid);
            foreach (var taskId in vm.Ids.Distinct())
            {
                var role = new RoleProfile
                {
                    TaskId = taskId,
                    RoleId = id,
                };
                _context.RoleProfiles.Add(role);
                await _context.SaveChangesAsync(Userid);
            }
            return RedirectToAction("Index");
        }


    
    }
}
