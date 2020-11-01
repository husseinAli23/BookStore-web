using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Model.Repository
{
    public class AutherRepository : IBookstoreRepository<Auther>
    {

        List<Auther> Authers;

        public AutherRepository()
        {

            Authers = new List<Auther>
            {
                new Auther {id=1, Fullname="hussain Ali"},
                new Auther {id=2, Fullname="mohammed"},
                new Auther {id=3, Fullname="hassa"},
            };
        }
        public void add(Auther auther)
        {
            auther.id = Authers.Max(b => b.id) + 1;
            Authers.Add(auther);
        }

        public void delete(int id)
        {
            var auther = Find(id);
            Authers.Remove(auther);
        }

        public Auther Find(int id)
        {
            var auther = Authers.SingleOrDefault(a=> a.id == id);
            return auther;
        }

        public List<Auther> List()
        {
            return Authers;
        }

        public List<Auther> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void update(int id, Auther newAuther)
        {
            var auther = Find(id);
            auther.Fullname= newAuther.Fullname;
        }
    }
}
