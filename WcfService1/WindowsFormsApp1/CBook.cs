﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CBook 
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public CBook(string title, string aurthor, decimal price, int inStock)
        {
            this.Title = title;
            this.Author = aurthor;
            this.InStock = inStock;
            this.Price = price;
        }
    }
    public class CListBooks
    {
        public IEnumerable<CBook> books { get; set; }
    }
}
