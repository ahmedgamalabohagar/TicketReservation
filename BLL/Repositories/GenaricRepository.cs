﻿using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _dbContext;

        public GenaricRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity) => _dbContext.Set<T>().Add(entity);


        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);

        public IEnumerable<T> GetAll() => _dbContext.Set<T>().Select(x => x).ToList();

        public T GetbyId(int id) => _dbContext.Set<T>().Where(x => x.Id == id).Select(x => x).FirstOrDefault();

        public void Update(T entity) => _dbContext.Set<T>().Update(entity);
    }
}
