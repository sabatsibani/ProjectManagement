using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using ProjectManagement.Shared;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Data.Implementation
{
    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            if (user == null)
                return null;

            if (!UserHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ApplicationError("Password is required");

            if (_context.Users.Any(x => x.Username == user.Username))
                throw new ApplicationError("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            UserHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User userParameter, string password = null)
        {
            var user = _context.Users.Find(userParameter.Id);

            if (user == null)
                throw new ApplicationError("User not found");

            if (!string.IsNullOrWhiteSpace(userParameter.Username) && userParameter.Username != user.Username)
            {
                if (_context.Users.Any(x => x.Username == userParameter.Username))
                    throw new ApplicationError("Username " + userParameter.Username + " is already taken");

                user.Username = userParameter.Username;
            }

            if (!string.IsNullOrWhiteSpace(userParameter.FirstName))
                user.FirstName = userParameter.FirstName;

            if (!string.IsNullOrWhiteSpace(userParameter.LastName))
                user.LastName = userParameter.LastName;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                UserHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
