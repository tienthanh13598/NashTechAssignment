using System;
using System.Collections.Generic;
using BookManagement.Models;
using BookManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDetalController : ControllerBase
    {
        private IRequestDetailService _brrd;
        public RequestDetalController(IRequestDetailService brrd)
        {
            _brrd = brrd;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<RequestDetail>> Get()
        {
            return _brrd.GetAll();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<RequestDetail> Get(Guid id)
        {
            return _brrd.GetById(id);
        }


        [HttpPost]
        //[Authorize(Roles = "Admin,User")]
        public void Post(RequestDetail brrd)
        {
            _brrd.Create(brrd);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public void Put(Guid id, RequestDetail brrd)
        {
            _brrd.Update(brrd);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public void Delete(Guid id)
        {
            _brrd.Delete(id);
        }
    }
}