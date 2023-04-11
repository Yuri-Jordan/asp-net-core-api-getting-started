using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var books = _bookRepository.GetAll();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var book = _bookRepository.GetById(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        _bookRepository.Add(book);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Book book)
    {
        var existingBook = _bookRepository.GetById(id);
        if (existingBook == null)
        {
            return NotFound();
        }
        book.Id = id;
        _bookRepository.Update(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var existingBook = _bookRepository.GetById(id);
        if (existingBook == null)
        {
            return NotFound();
        }
        _bookRepository.Delete(id);
        return NoContent();
    }
}
