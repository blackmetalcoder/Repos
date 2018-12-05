using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testInterface
{
    public interface Iname
    {
        string Name { get; set; }
    }
    class Employee : Iname
    {
        public string Name { get; set; }
    }

    
}
