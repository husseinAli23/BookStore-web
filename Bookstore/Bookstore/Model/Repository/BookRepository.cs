using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Model.Repository
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        List<Book> books;

        public BookRepository()
        {
            books = new List<Book>{
                new Book{ ID=1, Title="java" , description="sijfis", ImageURL="android-logo.jpg" ,Auther =new Auther{id=1} },
                new Book{ ID=2, Title="vue" , description="sijfis" ,ImageURL="JSON.png" , Auther =new Auther{id=2 } },
                new Book{ ID=3, Title="javascript" , description="sijfis" ,ImageURL="github.png" ,Auther =new Auther{id=3 } }
            };
        }

        public void add(Book entity)
        {
            entity.ID = books.Max(b=> b.ID)+1;
            books.Add(entity);
        }

        public void delete(int id)
        {
            var removeBook = Find(id);

            books.Remove(removeBook);


        }

        public Book Find(int id)
        {
            var FindBook = books.SingleOrDefault(b => b.ID == id);
            return FindBook;
        }

        public List<Book> List()
        {
            return books;
        }

        public List<Book> Search(String term)
        {
            throw new NotImplementedException();
        }

        public void update(int id, Book newBook)
        {
            var Book = Find(id);

            Book.Title = newBook.Title;
            Book.description = newBook.description;
            Book.Auther = newBook.Auther;
            Book.ImageURL = newBook.ImageURL;
        }   
    }
}
