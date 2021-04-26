using System;
using System.Collections.Generic;
using System.Linq;
using BookManagement.Enums;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services
{
    public class BookRequestService : IBookRequestService
    {
        private LibraryContext _context;
        public BookRequestService(LibraryContext context)
        {
            _context = context;
        }

        public bool Create(BookRequest entity)
        {
            throw new NotImplementedException();
        }

        public bool CreateRequest(Guid userId , List<Guid> bookIds)
        {
            try
            {
                var checkMonth = _context.BookRequests
                    .Count(x => x.RequestUserId == userId
                                && x.DateRequest.Month == DateTime.Now.Month
                                && x.DateRequest.Year == DateTime.Now.Year);

                if (bookIds.Count() > 5 || checkMonth > 2)
                {
                    return false;
                }
                else
                {
                    var request = new BookRequest {
                        RequestUserId = userId,
                        DateRequest = DateTime.Now,
                        Status =  Status.Waiting
                    };
                    _context.BookRequests.Add(request);
                    _context.SaveChanges();
                    
                    foreach(var item in bookIds)
                    {
                        var requestdetail = new RequestDetail {
                            RequestId = request.RequestId,
                            BookId = item
                        };
                        _context.RequestDetails.Add(requestdetail);
                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            var bbr = _context.BookRequests.FirstOrDefault(x => x.RequestId == id);
            try
            {
                _context.BookRequests.Remove(bbr);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<BookRequest> GetAll()
        {
           
            return _context.BookRequests.Include(x => x.RequestDetails).ToList();
        }

        public BookRequest GetById(Guid id)
        {
            return _context.BookRequests.Find(id);
        }
        public bool Update(BookRequest bbr)
        {
            try
            {
                var item = _context.BookRequests.Find(bbr.RequestId);
                item.DateRequest = bbr.DateRequest;
                item.Status = bbr.Status;
                item.RequestUserId = bbr.RequestUserId;
                item.ReturnRequest = bbr.ReturnRequest;
                item.RejectUserId = bbr.RejectUserId;
                item.ApprovalUserId = bbr.ApprovalUserId;
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