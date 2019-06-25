using Core.DataAccess;
using Core.Entities;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.LiteDb
{
    public class LiteDbRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
    {

        private LiteDatabase _context;
        public LiteCollection<TEntity> collection;


        public LiteDbRepository()
        {
            this._context = new LiteDatabase(@"MyDatabase.db");

            this.collection = this._context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        /// <summary>
        /// Db'den Entity datasını alır ve liste olarak döner.
        /// </summary>
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? this.collection.FindAll().ToList() : this.collection.Find(filter).ToList();
        }

        /// <summary>
        /// Id'ye göre entity çeker
        /// </summary>
        public TEntity GetById(int entityId)
        {
            return this.collection.FindById(entityId);
        }

        public void Insert(TEntity entity)
        {
            this.collection.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            this.collection.Update(entity);
        }
        public void Delete(int entityId)
        {
            this.Delete(entityId);
        }
    }
}
