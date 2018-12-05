using testInterface;

namespace IName
{
    internal interface IName
    {
        string Name { get; set; }
    }
    class Employee : Iname
    {
        public string Name { get; set; }
    }
}