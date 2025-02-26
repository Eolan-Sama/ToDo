﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTO;
using NLayer.Core.Models;
using NLayer.Core.Repo;
using NLayer.Repository;

namespace NLayer.Repo.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByToken(string token)
        {
            return await _dbSet.FindAsync(token);
        }

        public async Task<T> GetByMail(string mail)
        {
            return await _dbSet.FindAsync(mail);
        }


        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }


        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }


        public void Update(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Update(entity);
        }

    }
}
