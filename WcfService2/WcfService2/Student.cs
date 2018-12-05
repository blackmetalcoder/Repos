using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService2.models;

namespace WcfService2
{
    public class Student
    {
        public string RollNumber { get; set; }
        public string Name { get; set; }
    }

    public class Bocker : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
    }
}