using System;
using System.Collections.Generic;
using BookManagement.Enums;
using BookManagement.Models;
using BookManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookRequestController : ControllerBase
    {
        private readonly IBookRequestService _brr;
        private readonly IRequestDetailService _brrd;
        public BookRequestController(IBookRequestService brr, IRequestDetailService brrd)
        {
            _brr = brr;
            _brrd = brrd;

        }
        [HttpGet]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<BookRequest>> Get()
        {
            return _brr.GetAll();
        }

        [HttpGet("Admin")]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<BookRequest>> GetForAdmin()
        {
            return _brr.GetAll();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<BookRequest> Get(Guid id)
        {
            return _brr.GetById(id);
        }


        [HttpPost("{userId}")]
        //[Authorize(Roles = "Admin,User")]
        public IActionResult Post(Guid userId, List<Guid> bookIds)
        {
            if (_brr.CreateRequest(userId,bookIds))
            {  
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(Guid id, BookRequest brr)
        {
            id = brr.RequestId;
            if (_brr.Update(brr))
            {
                return Ok();
            }
            return BadRequest();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{userId}/approve/{id}")]
        public IActionResult ApproveBorrowRequest(Guid id,Guid userId)
        {
            var entity = _brr.GetById(id); 

            if (entity != null)
            {
                //entity.ApprovalUserId = Int32.Parse( HttpContext.Session.GetString("userId"));
                entity.Status = Status.Approve;
                entity.ApprovalUserId = userId;
                _brr.Update(entity);
                return Ok(entity);
            }
            return NoContent();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{userId}/reject/{id}/")]
        public IActionResult RejectBorrowRequest(Guid id, Guid userId)
        {
            var entity = _brr.GetById(id); 

            if (entity != null)
            {
                //entity.RejectUserId = Int32.Parse( HttpContext.Session.GetString("userId"));
                entity.Status = Status.Rejected;
                entity.RejectUserId = userId;
                _brr.Update(entity);
                return Ok(entity);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
       // [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            if (_brr.Delete(id))
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}