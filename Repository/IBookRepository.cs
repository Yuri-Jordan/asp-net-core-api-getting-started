public interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book GetById(Guid id);
    void Add(Book item);
    void Update(Book item);
    void Delete(Guid id);
}