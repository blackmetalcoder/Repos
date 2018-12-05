using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBooks
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestGetAllBooks()
        {
            ServiceService.BookstoreServiceClient client = new ServiceService.BookstoreServiceClient();
            object[] Books = await client.GetAllBooksAsync();
            var V = Books;
            client.Close();
        }
        [DataTestMethod]
        public async void TestGetTheBook(string book)
        {
            ServiceService.BookstoreServiceClient client = new ServiceService.BookstoreServiceClient();
            object[]Books = await client.GetAllBooksAsync();
            var V = Books;
            client.Close();
        }
    }
}
