using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TravelInn.Common;

namespace SharedKernel.Data
{

    public class GenericRepository<TEntity, Tlog> : Loggable where TEntity : class, IEntity, IValidate
                                                  where Tlog : class, ILog, new()
    {

        private string _currentUser = HttpContext.Current?.User.Identity.Name;

        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;
        internal DbSet<Tlog> _dbSetLog;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _dbSetLog = context.Set<Tlog>();
        }

        /// <summary>
        /// ALL
        /// </summary>
        public IEnumerable<TEntity> All()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> AllInclude
        (params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        // test yok
        public IEnumerable<TEntity> FindByInclude
          (Expression<Func<TEntity, bool>> predicate,
          params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.Where(predicate).ToList();
            return results;
        }

        // testi yok
        private IQueryable<TEntity> GetAllIncluding
        (params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbSet.AsNoTracking();

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        // testi yok
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {

            IEnumerable<TEntity> results = _dbSet.AsNoTracking()
              .Where(predicate).ToList();
            return results;
        }

        // testi yok
        public TEntity FindByKey(int id)
        {
            return _dbSet.AsNoTracking().SingleOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Id
        /// </summary>
        public int MaxId()
        {
            if (_dbSet.AsNoTracking().Select(c => c.Id).Take(1).Count() > 0)
            {
                return _dbSet.Max(c => c.Id);
            }
            else
            {
                return 0;
            }
        }

        public int NextId()
        {
            return MaxId() + 1;
        }

        /// <summary>
        /// Add
        /// </summary>
        public OperationResult Add(TEntity entity)
        {

            var opr = new OperationResult() { Success = true };

            if (entity.Validate().Success)
            {
                entity.Uniqueidentifier = Guid.NewGuid().ToString();
                entity.WhoInserted = this._currentUser;
                entity.WhenInserted = LocalTime.GetIstanbul();

                entity.Id = this.NextId();
                _dbSet.Add(entity);

                var a = entity.GetType().Name;

                // Log .........................
                _dbSetLog.Add(new Tlog()
                {
                    TableName = entity.GetType().Name.Length > 20 ? entity.GetType().Name.Substring(0, 20) : entity.GetType().Name,
                    LogString = Crud.Eklendi + " | " + this.Log(entity),
                    TimeStamp = LocalTime.GetIstanbul()
                });
                // ......................... Log

                try
                {
                    _context.SaveChanges();

                    return opr;
                }
                catch (Exception e)
                {
                    _dbSet.Remove(entity);
                    opr.Success = false;
                    opr.MessageList.Add("Ekleme basarisiz");

                    return opr;
                }
            }

            return entity.Validate();

        }

        /// <summary>
        /// Update
        /// </summary>
        public OperationResult Update(TEntity entity)
        {
            var opr = new OperationResult() { Success = true };

            if (entity.Validate().Success)
            {
                // preserve previous data ..........................
                var _entity = this.FindByKey(entity.Id);

                entity.Uniqueidentifier = _entity.Uniqueidentifier;
                entity.WhoInserted = _entity.WhoInserted;
                entity.WhenInserted = _entity.WhenInserted;
                entity.WhoUpdated = this._currentUser;
                entity.WhenUpdated = LocalTime.GetIstanbul();
                // ..........................preserve previous data 

                //_dbSet.Attach(entity);
                //_context.Entry(entity).State = EntityState.Modified;

                _context.Set<TEntity>().AddOrUpdate(entity);


                // Log .........................
                _dbSetLog.Add(new Tlog()
                {
                    TableName = entity.GetType().Name.Length > 20 ? entity.GetType().Name.Substring(0, 20) : entity.GetType().Name,
                    LogString = Crud.Guncellendi + " | " + this.Log(entity),
                    TimeStamp = LocalTime.GetIstanbul()
                });
                // ......................... Log

                try
                {
                    _context.SaveChanges();

                    return opr;
                }
                catch (Exception e)
                {
                    _dbSet.Remove(entity);
                    opr.Success = false;
                    opr.MessageList.Add("Update basarisiz");

                    return opr;
                }
            }

            return entity.Validate();

        }

        /// <summary>
        /// Remove
        /// </summary>
        public OperationResult Remove(int Id)
        {
            var opr = new OperationResult() { Success = true };

            var entity = _dbSet.FirstOrDefault(c => c.Id == Id);

            // preserve previous data ..........................
            var _entity = this.FindByKey(entity.Id);

            entity.Uniqueidentifier = _entity.Uniqueidentifier;
            entity.WhoInserted = _entity.WhoInserted;
            entity.WhenInserted = _entity.WhenInserted;
            entity.WhoUpdated = _entity.WhoUpdated;
            entity.WhenUpdated = _entity.WhenUpdated;
            entity.WhoDeleted = this._currentUser;
            entity.WhenDeleted = LocalTime.GetIstanbul();
            // ..........................preserve previous data 

            //Log.........................
            _dbSetLog.Add(new Tlog()
            {
                TableName = entity.GetType().Name.Length > 20 ? entity.GetType().Name.Substring(0, 20) : entity.GetType().Name,
                LogString = Crud.Silindi + " | " + this.Log(entity),
                TimeStamp = LocalTime.GetIstanbul()
            });
            //......................... Log

            try
            {
                _context.Entry(entity).State = EntityState.Deleted;

                _context.SaveChanges();

                return opr;
            }
            catch
            {
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                };
                opr.Success = false;
                opr.MessageList.Add("Silme basarisiz");

                return opr;
            }

        }
    }

    public enum Crud
    {
        Eklendi,
        Silindi,
        Guncellendi

    }
}
