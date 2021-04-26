using System;
using System.Collections.Generic;

namespace BookManagement.Services
{
    public interface IHandler<T> where T: class
    {
        //return list entity
        List<T> GetAll();
        //add new entity
        bool Create(T entity);
        //edit entity
        bool Update(T entity);
        //delete entity
        bool Delete(Guid id);
        //get entity by id
        T GetById(Guid id);

    }
}