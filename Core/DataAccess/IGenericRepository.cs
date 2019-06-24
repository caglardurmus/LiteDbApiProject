using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll();
        T GetEntityById(int entityId);
    }
}
