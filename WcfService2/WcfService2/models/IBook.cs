﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService2.models
{
    public interface IBook
    {
        string Title { get; }
        string Author { get; }
        decimal Price { get; }
        int InStock { get; }
    }
}
