using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using PersonStore.Controllers;
using PersonStore.Models;

namespace ExamWebAPI_UnitTest
{
    [TestClass]
    public class jUnitTest1
    {
        [TestMethod]
        public void GetAllPersons_ShouldReturnAllPersons()
        {
            TestPersonRepository testPersons = new TestPersonRepository();
            var ExpectedResult = testPersons.GetAll() as List<Person>;

            var controller = new PersonsController(testPersons);
            var result = controller.Get() as List<Person>;

            Assert.AreEqual(ExpectedResult.Count, result.Count);

        }

        [TestMethod]
        public void GetAllPersons_ShouldReturnCorrectPerson()
        {
            TestPersonRepository testPersons = new TestPersonRepository();
            var ExpectedResult = testPersons.GetByID(2) as Person;

            var controller = new PersonsController(testPersons);
            var result = controller.Get(2) as OkNegotiatedContentResult<Person>;
                
            Assert.AreEqual(ExpectedResult.FirstName.ToString(), result.Content.FirstName);

        }
    }

    public class TestPersonRepository : IPersonRepository
    {

        private List<Person> _people = new List<Person>();
        private int personID = 1;

        public TestPersonRepository()
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



