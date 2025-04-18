﻿using Microsoft.EntityFrameworkCore;

namespace Bug_Ticketing_System.DAL
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly BugDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(BugDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);
    }

}
