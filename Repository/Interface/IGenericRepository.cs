using Dapo.DataModel;
using System;
using System.Collections.Generic;

namespace Dapo.Repository
{
    public interface IGenericRepository
    {
        long Add<TEntity>(TEntity entity) where TEntity : DbObjectBase;
        long Add<TEntity>(IEnumerable<TEntity> entity) where TEntity : DbObjectBase;
        IEnumerable<TEntity> All<TEntity>() where TEntity : DbObjectBase;
        TEntity Find<TEntity>(long id) where TEntity : DbObjectBase;
        IEnumerable<TEntity> Filter<TEntity>(object whereClauseParams) where TEntity : DbObjectBase;
        bool Update<TEntity>(TEntity entity) where TEntity : DbObjectBase;
        void Update<TEntity>(IEnumerable<TEntity> entity) where TEntity : DbObjectBase;
        bool Delete<TEntity>(long id) where TEntity : DbObjectBase;
        int Execute(string sqlQuery);
        int ExecuteStoredProcedure(string storedProcedureName);
        IEnumerable<TEntity> Query<TEntity>(string sqlQuery) where TEntity : DbObjectBase;
        IEnumerable<TEntity> Query<TEntity>(string sqlQuery, object param) where TEntity : DbObjectBase;
    }
}