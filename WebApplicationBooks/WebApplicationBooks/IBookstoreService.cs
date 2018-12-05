using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using WebApplicationBooks.Models;

namespace WebApplicationBooks
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceBooks" in both code and config file together.
    [ServiceContract]
    
    public interface IBookstoreService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        Task<IEnumerable<IBook>> GetBooksAsync(string searchString);
        [OperationContract]
        Task<List<CBook>> GetAllBooksAsync();
        /*[OperationContract]
        List<CBook> BockerLista();*/
        [OperationContract]
        List<string> GetGeneralNewsFeed();
    }
}
