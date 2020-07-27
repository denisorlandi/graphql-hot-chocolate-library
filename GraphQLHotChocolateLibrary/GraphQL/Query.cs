using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

public class Query
{
    [GraphQLNonNullType]
    public List<Book> GetBooks([Service] BookDbContext dbContext) => dbContext.Books.Include(x => x.Author).ToList();

    //By convention GetBook() will be declared book() in the query type.
    public Book GetBook([Service] BookDbContext dbContext, int id) => dbContext.Books.FirstOrDefault(x => x.Id == id);
}
