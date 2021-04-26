using System;
using System.Collections.Generic;
using BookManagement.Models;
using BookManagement.Services;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookservice;
        public BookController(IBookService bookService)
        {
            _bookservice = bookService;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return _bookservice.GetAll();
        }
        [HttpGet("Admin")]
        //[Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<Book>> GetForAdmin()
        {
            return _bookservice.GetAll();
        }
        
        [HttpGet("{id}")]

        //[Authorize(Roles = "Admin,User")]
        public ActionResult<Book> Get(Guid id)
        {
            return _bookservice.GetById(id);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult Post(Book book)
        {
            if (_bookservice.Create(book))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Put(Guid id, Book book)
        {
            id = book.BookId;
            if (_bookservice.Update(book))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
       // [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            if (_bookservice.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}