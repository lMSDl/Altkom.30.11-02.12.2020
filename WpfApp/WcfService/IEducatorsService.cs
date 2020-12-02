using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEducatorsService" in both code and config file together.
    [ServiceContract]
    public interface IEducatorsService
    {
        [OperationContract]
        Task<IEnumerable<Educator>> ReadAsync();
    }
}
