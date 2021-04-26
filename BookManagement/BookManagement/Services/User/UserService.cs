using System;
using System.Collections.Generic;
using System.Linq;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services
{
    public class UserService : IUserService
    {
        private LibraryContext _context;
        public UserService(LibraryContext context)
        {
            _context = context;
        }
        public  bool Create(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;

            }
            catch 
            {
                return false;
            }

        }

        public bool Delete(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == id);
            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;

            }
            catch 
            {
                return false;
            }

        }

        public List<User> GetAll()
        {
            return _context.Users.Include(x=>x.BookRequests).ToList();
        }

        public User GetById(Guid id) 
        {
            return _context.Users.Find(id);
        }

        public bool Update(User user)
        {
            try
            {
                var item = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
                item.Username = user.Username;
                item.DoB = user.DoB;
                item.Name = user.Name;
                item.Password = user.Password;
                item.Role = user.Role;
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }

        }
       
    }
}