using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Bookstore.Model.Repository
{
    public interface IBookstoreRepository<TEntity>
    {
        List<TEntity> List();
        TEntity Find(int id);
        void add(TEntity tentity);
        void update(int id, TEntity tentity);
        void delete(int id);
        List<TEntity> Search(String term);

    }
}
