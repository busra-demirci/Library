using System;
using Library.DTO;
using Library.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.UnitTest
{
    [TestClass]
    public class BookUT
    {
        private BookService service;

        [TestInitialize]
        public void Setup()
        {
            service = new BookService();
        }

        [TestMethod]
        public void Save()
        {
            BookDTO book1 = new BookDTO
            {
                BookName = "Suç ve Ceza",
                GenreId = 4,
                Author = "Dostoyevski",
                PublishDate = new DateTime(2019, 1, 1),
                UnitsInStock = 20
            };

            BookDTO book2 = new BookDTO
            {
                BookName = "Kara Kule",
                GenreId = 1,
                Author = "Stephen King",
                PublishDate = new DateTime(1980, 1, 1),
                UnitsInStock = 5
            };

            BookDTO book3 = new BookDTO
            {
                BookName = "Harry Potter",
                GenreId = 2,
                Author = "J. K. Rowling",
                PublishDate = new DateTime(2015, 1, 1),
                UnitsInStock = 15
            };

            BookDTO book4 = new BookDTO
            {
                BookName = "Şu Çılgın Türkler",
                GenreId = 5,
                Author = "Turgut Özakman",
                PublishDate = new DateTime(2014, 1, 1),
                UnitsInStock = 30
            };

            var result2 = service.Save(book2);
            var result3 = service.Save(book3);
            var result4 = service.Save(book4);

            Assert.IsNotNull(result2);
            Assert.IsNotNull(result3);
            Assert.IsNotNull(result4);
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
            BookDTO book1 = new BookDTO
            {
                BookId = 1,
                BookName = "Suç ve Ceza",
                GenreId = 4,
                Author = "Dostoyevski",
                PublishDate = new DateTime(2019, 1, 1),
                UnitsInStock = 15,
                CreatedDate = DateTime.Now,
                RecordStatusId = Convert.ToByte(Enums.RecordStatus.Aktif)
            };

            var result = service.Update(book1);

            Assert.IsTrue(result);
        }
    }
}
