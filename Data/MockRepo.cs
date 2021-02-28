using System.Collections.Generic;
using System.Linq;

using AspNetCoreWebApiIntro.Models;

namespace AspNetCoreWebApiIntro.Data
{
    public class MockRepo
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Jane", LastName = "Doe" },
            new User { Id = 2, FirstName = "John", LastName = "Doe" },
            new User { Id = 3, FirstName = "John", LastName = "Smith" }
        };

        public IEnumerable<User> GetAllUsers()
        {
            return this._users;
        }

        public User GetUserById(int id)
        {
            return this._users.FirstOrDefault(u => u.Id == id);
        }
    }
}
