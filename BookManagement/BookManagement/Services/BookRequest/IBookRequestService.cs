using System;
using System.Collections.Generic;
using BookManagement.Models;

namespace BookManagement.Services
{
    public interface IBookRequestService : IHandler<BookRequest>
    {
        bool CreateRequest(Guid userId , List<Guid> bookIds);
     
    }
}