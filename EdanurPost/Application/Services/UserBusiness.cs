using Abstract.Services;
using Domain.Dto;
using Domain.Entities;
using Infracture.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class UserBusiness : IUserServices
    {
        private readonly EdanurContext _context;

        public UserBusiness(EdanurContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            var data = _context.Users.AsEnumerable();
            return data;
        }

        public void Update(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Job = user.Job;

                _context.Entry(existingUser).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public UserDto GetByID(int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            UserDto userDto = new UserDto() { Name = user.Name, Email = user.Email, Job = user.Job };
            return userDto;
        }
    }
}
