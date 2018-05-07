using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dapo.DataModel;
using Dapper.Contrib.Extensions;

namespace Dapo.Repository
{
    internal class GenericRepository : RepositoryBase, IGenericRepository
    {
        public GenericRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public long Add<TEntity>(TEntity entity) where TEntity : DbObjectBase
        {
            return Connection.Insert<TEntity>(entity, transaction: Transaction);
        }
        public long Add<TEntity>(IEnumerable<TEntity> entity) where TEntity : DbObjectBase
        {
            foreach (var item in entity)
            {
                Connection.Insert<TEntity>(item, transaction: Transaction);
            }
            return 0;
        }
        public IEnumerable<TEntity> All<TEntity>() where TEntity : DbObjectBase
        {
            return Connection.GetAll<TEntity>(transaction: Transaction).AsEnumerable<TEntity>().Where(q => q.IsDeleted == false);
        }
        public IEnumerable<TEntity> Filter<TEntity>(object whereClauseParams) where TEntity : DbObjectBase
        {
            IDapperQueryPartsGenerator<TEntity> instance = new DapperQueryPartsGenerator<TEntity>();
            return Connection.Query<TEntity>(instance.GenerateSelect(whereClauseParams), whereClauseParams, transaction: Transaction).Where(q => q.IsDeleted == false);
        }
        public TEntity Find<TEntity>(long id) where TEntity : DbObjectBase
        {
            return Connection.Get<TEntity>(id, transaction: Transaction);
        }
        public bool Update<TEntity>(TEntity entity) where TEntity : DbObjectBase
        {
            return Connection.Update<TEntity>(entity, transaction: Transaction);
        }
        public void Update<TEntity>(IEnumerable<TEntity> entity) where TEntity : DbObjectBase
        {
            Connection.Update<IEnumerable<TEntity>>(entity, transaction: Transaction);
        }
        public bool Delete<TEntity>(long id) where TEntity : DbObjectBase
        {
            bool IsDeleted = false;
            TEntity entity = Find<TEntity>(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                IsDeleted = Update<TEntity>(entity);
            }
            return IsDeleted;
        }
        public int Execute(string sqlQuery)
        {
            return Connection.Execute(sqlQuery, transaction: Transaction);
        }
        public int ExecuteStoredProcedure(string storedProcedureName)
        {
            return Connection.Execute(storedProcedureName, commandType: CommandType.StoredProcedure, transaction: Transaction);
        }
        public void ExecuteQuery(string sqlQuery)
        {
            Connection.Execute(sqlQuery, transaction: Transaction);
        }
        public IEnumerable<TEntity> Query<TEntity>(string sqlQuery) where TEntity : DbObjectBase
        {
            return Connection.Query<TEntity>(sqlQuery, transaction: Transaction);
        }
        public IEnumerable<TEntity> Query<TEntity>(string sqlQuery, object parammeters) where TEntity : DbObjectBase
        {
            return Connection.Query<TEntity>(sqlQuery, param: parammeters, transaction: Transaction);
        }
        public TEntity SingleSelectFilter<TEntity>(object whereClauseParams) where TEntity : DbObjectBase
        {
            IDapperQueryPartsGenerator<TEntity> instance = new DapperQueryPartsGenerator<TEntity>();
            return Connection.QuerySingle<TEntity>(instance.GenerateSelect(whereClauseParams), whereClauseParams, transaction: Transaction);
        }
    }
}
