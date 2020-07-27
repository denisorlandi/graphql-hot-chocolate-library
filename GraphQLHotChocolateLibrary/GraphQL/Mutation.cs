using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;

public class Mutation
{
    public async Task<Book> Book([Service] BookDbContext dbContext, string title, int pages, string author, int chapters)
    {
        var book = new Book
        {
            Title = title,
            Chapters = chapters,
            Pages = pages,
            Author = new Author { Name = author }
        };

        dbContext.Books.Add(book);
        await dbContext.SaveChangesAsync();

        return book;
    }
}

