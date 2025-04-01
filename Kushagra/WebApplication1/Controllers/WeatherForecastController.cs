using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Data;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet(Name = "GetHello")]
        public IActionResult Get()
        {
            return Ok("Hello from the new route!");
        }
    }
}
namespace BookshopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookshopContext _context;

        public BooksController(BookshopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _context.Books.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Price = updatedBook.Price;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

