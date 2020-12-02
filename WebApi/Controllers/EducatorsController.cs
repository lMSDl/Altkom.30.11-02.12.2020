using DAL.Services;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class EducatorsController : ApiController
    {
        private IEducatorsService Service { get; } = new DbEducatorsService();

        [HttpGet]
        public Task<IEnumerable<Educator>> Read()
        {
            Thread.Sleep(5000);
            return Service.ReadAsync();
        }

        // GET api/values/5
        public Task<Educator> Get(int id)
        {
            return Service.ReadAsync(id);
        }

        // api/Educators/Specialization/[value]
        [Route("api/Educators/Specialization/{specialization}")]
        public IEnumerable<Educator> GetBySpecialization([FromUri]string specialization)

        // api/Educators?specialization=[value]
        //public IEnumerable<Educator> GetBySpecialization([FromUri]string specialization)
        {
            return Service.ReadBySpecialization(specialization);
        }

        // POST api/values
        public Task<int> Post([FromBody]Educator educator)
        {
            return Service.CreateAsync(educator);
        }

        // PUT api/values/5
        public Task Put(int id, [FromBody]Educator educator)
        {
            return Service.UpdateAsync(id, educator);
        }

        // DELETE api/values/5
        public Task Delete(int id)
        {
            return Service.DeleteAsync(id);
        }
    }
}
