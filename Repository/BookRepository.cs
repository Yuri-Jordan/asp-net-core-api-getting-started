public class BookRepository : IBookRepository
{
    private readonly BooksContext _context;

    public BookRepository(BooksContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetAll()
    {
        return _context.Books;
    }

    public Book GetById(Guid id)
    {
        return _context.Books.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Book item)
    {
        _context.Books.Add(item);
        Save();
    }

    public void Update(Book item)
    {
        var existingItem = _context.Books.FirstOrDefault(x => x.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.Title = item.Title;
            existingItem.Author = item.Author;
            existingItem.Year = item.Year;
        }
        Save();
    }

    public void Delete(Guid id)
    {
        var itemToRemove = _context.Books.FirstOrDefault(x => x.Id == id);
        if (itemToRemove != null)
        {
            _context.Books.Remove(itemToRemove);
        }
        Save();
    }

    private void Save()
    {
        _context.SaveChanges();
    }
}