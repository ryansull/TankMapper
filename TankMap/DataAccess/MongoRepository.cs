using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Norm;
using TankMap.Models;

namespace TankMap.DataAccess
{
    public class MongoRepository<T> : IRepository<T> where T : IModel
    {
        #region Variables

        private readonly string _connectionString;

        #endregion

        #region Constructors

        public MongoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Public Methods

        public IEnumerable<T> All()
        {
            return Read(db => db.GetCollection<T>().Find());
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return Read(db => db.GetCollection<T>().Find().Where(predicate));
        }

        public T SingleOrDefault(Func<T, bool> predicate)
        {
            return ReadOne(db => db.GetCollection<T>().Find().SingleOrDefault(predicate));
        }

        public int NextId()
        {
            var max = All().Count() > 0 ? All().Max(i => i.ID) : 0;
            return (max + 1);
        }

        public void Save(T entity)
        {
            if (entity.ID == 0) entity.ID = NextId();
            if (entity.DateCreated.Year == 1) entity.DateCreated = DateTime.Now;

            Write(db => db.GetCollection<T>().Save(entity));
        }

        public void Delete(T entity)
        {
            Write(db => db.GetCollection<T>().Delete(entity));
        }

        public int Count(Func<T, bool> predicate)
        {
            return Where(predicate).Count();
        }

        #endregion

        #region Private Methods

        private Mongo GetConnection()
        {
            try
            {
                return Mongo.Create(_connectionString) as Mongo;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        private IEnumerable<T> Read(Func<Mongo, IEnumerable<T>> action)
        {
            using (var db = GetConnection()) { return action(db); }
        }

        private T ReadOne(Func<Mongo, T> action)
        {
            using (var db = GetConnection()) { return action(db); }
        }

        private void Write(Action<Mongo> action)
        {
            using (var db = GetConnection()) { action(db); }
        }

        #endregion
    }
}