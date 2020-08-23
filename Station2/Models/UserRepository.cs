using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void LockUser(string userId)
        {
            var userFromDb = _appDbContext.Users.FirstOrDefault(u => u.Id == userId);
            userFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            _appDbContext.SaveChanges();
        }

        public void UnLockUser(string userId)
        {
            var userFromDb = _appDbContext.Users.FirstOrDefault(u => u.Id == userId);
            userFromDb.LockoutEnd = DateTime.Now;
            _appDbContext.SaveChanges();
        }
    }
}
