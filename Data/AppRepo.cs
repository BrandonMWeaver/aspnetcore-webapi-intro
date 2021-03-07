using System.Collections.Generic;
using System.Linq;

using AspNetCoreWebApiIntro.Models;

namespace AspNetCoreWebApiIntro.Data
{
    public class AppRepo
    {
        private readonly AppContext _context;

        public AppRepo(AppContext context)
        {
            this._context = context;
        }

        public bool SaveChanges()
        {
            return this._context.SaveChanges() >= 0;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this._context.Users;
        }

        public User GetUserById(int id)
        {
            return this._context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void CreateUser(User user)
        {
            this._context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            this._context.Users.Remove(user);
        }
    }
}
