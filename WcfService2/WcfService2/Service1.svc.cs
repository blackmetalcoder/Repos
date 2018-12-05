using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WcfService2.models;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        List<Student> lstStudent = new List<Student>();
        List<Bocker> lstBook = new List<Bocker>();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public async Task<IEnumerable<Bocker>> GetJson()
        {
            var url = "https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json";
            var books = BooksSource._download_serialized_json_data<CListBooks>(url);
            var V = books.books;
            foreach (var item in V)
            {
                Bocker b = new Bocker();
                b.Author = item.Author;
                b.InStock = item.InStock;
                b.Price = item.Price;
                b.Title = item.Title;
                lstBook.Add(b);
            }
            return lstBook;
            /*var Boker = await BooksSource.GetIT();
            return Boker;*/
        }

        public async Task<IEnumerable<IBook>> GetJsonFile()
        {
            var Lista = BooksSource.JsonFromFile();

            return Lista;
        }

        public IEnumerable<Student> GetStudents()
        {
            Student S = new Student();
            S.RollNumber = "1";
            S.Name = "Ian";
            lstStudent.Add(S);

            Student S1 = new Student();
            S1.RollNumber = "2";
            S1.Name = "Bamse";
            lstStudent.Add(S1);

            Student S2 = new Student();
            S2.RollNumber = "2";
            S2.Name = "Olle";
            lstStudent.Add(S2);

            return lstStudent;
        }

        public async Task<IEnumerable<Student>> getTask()
        {
            Student S = new Student();
            S.RollNumber = "1";
            S.Name = "Ian";
            lstStudent.Add(S);

            Student S1 = new Student();
            S1.RollNumber = "2";
            S1.Name = "Bamse";
            lstStudent.Add(S1);

            Student S2 = new Student();
            S2.RollNumber = "2";
            S2.Name = "Olle";
            lstStudent.Add(S2);

            return lstStudent ;
        }

        public CompositeType Test()
        {
            CompositeType P = new CompositeType();
            return P;
        }

        
    }
}
