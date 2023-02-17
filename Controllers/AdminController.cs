using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskAuthenticationAuthorization.Models;

namespace TaskAuthenticationAuthorization.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ShoppingContext _context;

        public AdminController(ShoppingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Roles"] = new SelectList(_context.Roles, "Id", "Name");
            var shoppingContext = _context.Users.Include(u => u.Role);
            return View(shoppingContext.ToList());
        }

        [HttpPost]
        public IActionResult Index(IEnumerable<User> users)
        {
            bool updated = false;
            foreach (var user in users)
            {
                if (_context.Users.Any(u => u.Id == user.Id))
                {
                    var toUpdate = _context.Users.FirstOrDefault(u => u.Id == user.Id);
                    if (toUpdate.BuyerType != user.BuyerType)
                    {
                        _context.Users.FirstOrDefault(u => u.Id == user.Id).BuyerType = user.BuyerType;
                        updated = true;
                    }
                    if (toUpdate.RoleId != user.RoleId)
                    {
                        _context.Users.FirstOrDefault(u => u.Id == user.Id).RoleId = user.RoleId;
                        updated = true;
                    }
                }
            }
            _context.SaveChanges();
            TempData["updated"] = updated;
            return RedirectToAction("Index");
        }
    }
}