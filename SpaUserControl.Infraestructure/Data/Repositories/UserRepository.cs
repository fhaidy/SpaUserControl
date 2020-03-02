using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace SpaUserControl.Infraestructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _context;

        public UserRepository(AppDataContext context)
        {
            _context = context;
        }

        public User Get(Guid id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }
        public User Get(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email.ToLower().Equals(email.ToLower()));
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry<User>(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
