using System;
using Library.DTO;
using Library.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.UnitTest
{
    [TestClass]
    public class StudentUT
    {
        private StudentService service;

        [TestInitialize]
        public void Setup()
        {
            service = new StudentService();
        }

        [TestMethod]
        public void Save()
        {
            StudentDTO student1 = new StudentDTO
            {
                FirstName = "Bülent",
                LastName = "Başyurt",
                StudentNumber = "555777",
                MobilePhone = "05412279878",
                EmailAddress = "bulentbasyurt@gmail.com"
            };

            StudentDTO student2 = new StudentDTO
            {
                FirstName = "Mehmet",
                LastName = "Çetin",
                StudentNumber = "777888",
                MobilePhone = "05414445566",
                EmailAddress = "mehmetcetin@gmail.com"
            };

            var result1 = service.Save(student1);
            var result2 = service.Save(student2);

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
        }

        [TestMethod]
        public void List()
        {
            var result = service.List();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get()
        {
            int id = 1;
            var result = service.Get(id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Update()
        {
            StudentDTO student1 = new StudentDTO
            {
                StudentId = 1,
                FirstName = "Bülent",
                LastName = "Başyurt",
                StudentNumber = "112233",
                MobilePhone = "05412279878",
                EmailAddress = "bulentbasyurt@hotmail.com",
                RecordStatusId = Convert.ToByte(Enums.RecordStatus.Aktif),
                CreatedDate = DateTime.Now
            };

            var result = service.Update(student1);

            Assert.IsTrue(result);
        }
    }
}
