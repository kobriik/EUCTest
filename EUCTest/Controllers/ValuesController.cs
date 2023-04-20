using EUCTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EUCTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly EucDatabaseContext _db;

        public ValuesController(EucDatabaseContext db)
        {
            _db = db;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _db.People.Include(x => x.Sex).Include(x => x.Country).ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _db.People.Include(x => x.Sex).Include(x => x.Country).FirstOrDefault(x => x.Id == id);
        }

    }
}
