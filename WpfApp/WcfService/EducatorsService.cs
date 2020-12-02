using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DAL.Services;
using Models;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EducatorsService" in both code and config file together.
    public class EducatorsService : IEducatorsService
    {
        public Task<IEnumerable<Educator>> ReadAsync()
        {
            return new DbEducatorsService().ReadAsync();
        }
    }
}
