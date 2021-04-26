using System;
using System.Collections.Generic;
using System.Linq;
using BookManagement.Models;

namespace BookManagement.Services
{
    public class RequestDetailService : IRequestDetailService
    {
        private LibraryContext _context;
        public RequestDetailService(LibraryContext context)
        {
            _context = context;
        }
        public  bool Create(RequestDetail bbrd)
        {
            try
            {
                _context.RequestDetails.Add(bbrd);
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
            var bbrd = _context.RequestDetails.FirstOrDefault(x => x.Id == id);
            try
            {
                _context.RequestDetails.Remove(bbrd);
                _context.SaveChanges();
                return true;


            }
            catch 
            {
                return false;
            }

        }

        public List<RequestDetail> GetAll()
        {
            return _context.RequestDetails.ToList();
        }

        public RequestDetail GetById(Guid id) 
        {
            return _context.RequestDetails.Find(id);
        }
        public bool Update(RequestDetail brrd)
        {
            try
            {
                var item = _context.RequestDetails.FirstOrDefault(x => x.Id == brrd.Id);
                item.BookId = brrd.BookId;
                item.RequestId = brrd.RequestId;
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