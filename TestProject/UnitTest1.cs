using EUCTest.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var mockSet = new Mock<DbSet<Person>>();
            var mockContext = new Mock<EucDatabaseContext>();
            mockContext.Setup(m => m.People).Returns(mockSet.Object);

            var item = new Person()
            {
                FirstName = "Test",
                LastName = "Test2",
                CountryId = 1,
                Birthdate = DateTime.Now,
                Email = "Test@test.cz",
                GdprAgree = true,
                IdentityNumber = "565544/2677",
                SexId = 1,
            };

            mockContext.Object.People.Add(item);
            mockContext.Object.SaveChanges();
            mockSet.Verify(m => m.Add(It.IsAny<Person>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}