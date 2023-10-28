using App.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseModel
    {
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void DeleteById(int id);
        void DeleteAll();
        void Delete(TEntity entity);
        void Remove(TEntity entity);
        void Remove(int id);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Insert(TEntity entity);
        void InsertRange(List<TEntity> entities);
        IQueryable<TEntity> GetAsQueryable();
    }
}
