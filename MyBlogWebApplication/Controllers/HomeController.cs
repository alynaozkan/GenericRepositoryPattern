using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.DataAccess.Repositories.Abstractions;
using Presentation.Entities.Concrete.PersonData;


namespace MyBlogWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IRepository<Person> _personRepo;


        public HomeController(ILogger<HomeController> logger, IRepository<Person> personRepo)
        {
            _logger = logger;
            _personRepo = personRepo;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {

            var newPerson = new Person
            {
                Name = person.Name,
                Surname = person.Surname,
                EntryInfo = person.EntryInfo
            };

            var personData = await _personRepo.AddAsync(newPerson);

            return Ok("Person added successfully.");
        }

        [HttpGet("GetPeopleData")]
        public async Task<IActionResult> GetPeopleData()
        {
            var s = await _personRepo.GetAllAsync(null, x => x.EntryInfo);
            return Ok(s);

        }

        [HttpGet("GetStatic")]
        public async Task<IActionResult> GetStatic()
        {
            var s = await _personRepo.GetbyIdAsync(2);
            return Ok(s);

        }

        [HttpGet("CustomGet/{id}")]
        public async Task<IActionResult> CustomGet(int id)
        {
           var s = await _personRepo.GetWithLazyLoadingAsync(x=>x.Id==id, x => x.Include(x => x.EntryInfo));
            return Ok(s);
        }
        
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
