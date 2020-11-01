using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Model.Repository
{
    public class BookDbRepository : IBookstoreRepository<Book>
    {
        BookstoreDbContext db;
        public BookDbRepository(BookstoreDbContext _db)
        {
            db = _db;
        }
        public void add(Book entity)
        {
            db.Book.Add(entity);
            save();
        }
        public void delete(int id)
        {
            var removeBook = Find(id);
            db.Book.Remove(removeBook);
            save();
        }
        public Book Find(int id)
        {
            var FindBook = db.Book.Include(a => a.Auther).SingleOrDefault(b => b.ID == id);
            return FindBook;
        }

        public List<Book> List()
        {
            return db.Book.Include(a => a.Auther).ToList();
        }

        public List<Book> Search(string term)
        {
            var result = db.Book.Include(a=>a.Auther)
                .Where(b=>b.Title.Contains(term) 
                      || b.description.Contains(term)
                      || b.Auther.Fullname.Contains(term)).ToList();

                return result;
        }

        public void update(int id, Book newBook)
        {
            db.Update(newBook);
            save();
        }
        private void save()
        {
            db.SaveChanges();
        }
    }
}
