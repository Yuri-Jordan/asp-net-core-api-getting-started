public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public static Book GetNewBook()
    {
        return new Book()
        {
            Title = "new book",
            Author = "fuleinow",
            Year = 1990
        };
    }
}