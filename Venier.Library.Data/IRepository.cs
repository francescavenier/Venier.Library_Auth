using System;
using System.Collections.Generic;
using System.Text;

namespace Venier.Library.Data
{
    public interface IRepository<TEntity,TPrimaryKey>
    {
        TEntity Get(TPrimaryKey id);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity model);
        void Update(TEntity model);
        void Delete(TPrimaryKey id);
    }
}
