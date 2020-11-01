using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Model.Repository
{
    public class AutherDbRepository: IBookstoreRepository<Auther>
    {

        BookstoreDbContext db;

        public AutherDbRepository(BookstoreDbContext _db) 
        {
            db = _db;
        }
        public void add(Auther auther)
        {
          //  auther.id = db.Auther.Max(b => b.id) + 1;
            db.Auther.Add(auther);
            save();
        }

        public void delete(int id)
        {
            var auther = Find(id);
            db.Auther.Remove(auther);
            save();
        }

        public Auther Find(int id)
        {
            var auther = db.Auther.SingleOrDefault(a => a.id == id);
            return auther;
        }

        public List<Auther> List()
        {
            return db.Auther.ToList();
        }

        public List<Auther> Search(String term)
        {
            var result = db.Auther.Where(a=>a.Fullname.Contains(term)).ToList();

            return result;
        }

        public void update(int id, Auther newAuther)
        {
            db.Update(newAuther);
            save();
        }

        private void save()
        {
            db.SaveChanges();
        }
    }
}
