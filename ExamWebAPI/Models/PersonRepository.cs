using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonStore.Models
{
    public class PersonRepository : IPersonRepository
    {
        
        private List<Person> _people = new List<Person>();
        private int personID = 1;

        public PersonRepository()
        {
            this.Add(new Person { LastName = "World", FirstName = "" });
            this.Add(new Person { LastName = "Washington", FirstName = "Denzel" });
            this.Add(new Person { LastName = "Cage", FirstName = "Nicolas" });
            this.Add(new Person { LastName = "DiCaprio", FirstName = "Leonardo" });
            this.Add(new Person { LastName = "Pitt", FirstName = "Brad" });
        }


        public IEnumerable<Person> GetAll()
        {
            return _people;
        }
        public Person GetByID(int id)
        {
            return _people.Find(p => p.Id == id);
        }

        public Person Add(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            person.Id = personID++;
            _people.Add(person);
            return person;
        }




    }
}