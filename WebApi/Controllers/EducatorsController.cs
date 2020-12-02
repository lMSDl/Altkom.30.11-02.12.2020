using DAL.Services;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class EducatorsController : ApiController
    {
        private IEducatorsService Service { get; } = new DbEducatorsService();

        [HttpGet]
        public IEnumerable<Educator> Read()
        {
            return Service.Read();
        }

        // GET api/values/5
        public Educator Get(int id)
        {
            return Service.Read(id);
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
        public int Post([FromBody]Educator educator)
        {
            return Service.Create(educator);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Educator educator)
        {
            Service.Update(id, educator);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Service.Delete(id);
        }
    }
}
