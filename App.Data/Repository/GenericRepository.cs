using App.Base;
using App.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel
    {
        private readonly ApContext _context;
        public GenericRepository(ApContext context) { 
            _context = context;

        }

        public void Delete(TEntity entity)
        {
           entity.IsActive = false;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = 1;
            _context.Set<TEntity>().Update(entity);
        }

        public void DeleteAll()
        {
            _context.Set<TEntity>().RemoveRange();
        }

        public void DeleteById(int id)
        {
          var entity=_context.Set<TEntity>().Find(id);
            entity.IsActive = false;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = 1;
            _context.Set<TEntity>().Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void InsertRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
