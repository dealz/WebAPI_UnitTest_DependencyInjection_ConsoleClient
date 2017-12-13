using System;
using System.Collections.Generic;
namespace PersonStore.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetByID(int id);

        Person Add(Person person);
       
    }
}
