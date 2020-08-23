using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Station2.Models;

namespace Station2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
         private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;


        public UserController(AppDbContext context, IUserRepository userRepository)
            {
                _context = context;
                _userRepository = userRepository;
            }
            public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return View(await _context.Users.Where(a => a.Id!= claims.Value).ToListAsync());
            
            //return View(_context.Users.FirstOrDefaultAsync(m => m.Id != claims.Value));

        }

        public IActionResult Lock(string id)
        {
            if(id==null)
            {
                return NotFound();
            }
            _userRepository.LockUser(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UnLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _userRepository.UnLockUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}