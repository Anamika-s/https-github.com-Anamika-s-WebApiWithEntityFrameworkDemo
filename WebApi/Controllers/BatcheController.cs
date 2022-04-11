using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Infrastructure;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BatchController : ControllerBase
    {
        private IRepository _repo;

        public BatchController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Batch> Get()
        {
            return _repo.GetAllBatches();
         
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Batch Get(int id)
        {
            return _repo.GetBatchDetailsById(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Batch batch)
        {
            _repo.CreateNewBatch(batch);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Batch batch)
        {
            _repo.EditBatchDetails(id, batch);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteBatch(id);
        }
    }
}
