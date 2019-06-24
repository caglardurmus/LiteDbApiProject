using Core.DataAccess;
using Core.Entities;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LiteDb
{
    public class LiteDbRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
    {

        public LiteDatabase _context = null;

        public LiteDbRepository()
        {
            this._context = new LiteDatabase(@"MyDatabase.db");
        }

        /// <summary>
        /// Db'den Entity datasını alır ve liste olarak döner.
        /// </summary>
        public List<TEntity> GetAll()
        {
            var data = this._context.GetCollection<TEntity>(typeof(TEntity).Name);

            return data.FindAll().ToList();
        }

        /// <summary>
        /// Id'ye göre entity çeker
        /// </summary>
        public TEntity GetEntityById(int entityId)
        {
            var data = this._context.GetCollection<TEntity>(typeof(TEntity).Name);

            return data.FindById(entityId);
        }
    }
}
