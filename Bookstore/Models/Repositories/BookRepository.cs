using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositories
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Title = "c# programming",
                    Description = "No description",
                    ImageUrl = "17309534_1942980299270310_2414832596500554968_n.jpg",
                    Author = new Author{Id = 1}
                },
                new Book
                {
                    Id = 2,
                    Title = "Java programming",
                    Description = "Nothing",
                    ImageUrl = "tumblr_omblgx7Jor1qegyoeo4_1280.jpg",
                    Author = new Author()
                },
                new Book
                {
                    Id = 3,
                    Title = "Python programming",
                    Description = "No data",
                    ImageUrl = "17190649_1940127832888890_7800107738520752066_n.jpg",
                    Author = new Author()
                }
            };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);

            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> list()
        {
            return books;
        }

        public List<Book> Search(string term)
        {
            return books.Where(a => a.Title.Contains(term)).ToList();
        }

        public void Update(int id, Book newbook)
        {
            var book = Find(id);

            book.Title = newbook.Title;
            book.Description = newbook.Description;
            book.Author = newbook.Author;
            book.ImageUrl = newbook.ImageUrl;
        }
    }
}
