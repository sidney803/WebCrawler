using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassCrawler.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassCrawler.Data.Repository
{
    public class GenericRepository<TEntity> where TEntity: class 
    {
        private readonly ClassMariaDbContext _dbContext;

        public GenericRepository()
        {
            //_dbContext = new ClassDbContext();
            _dbContext = new ClassMariaDbContext();
        }

        public IQueryable<TEntity> GetAll()
        {
            var entity = _dbContext.Set<TEntity>().AsNoTracking();
            return entity;
        }

        public async Task CreateAsync(TEntity entity)
        {
            //await _dbContext.Set<IEnumerable<ClassInfo>>().AddAsync(entity);
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        /*
        public async Task UpdateAsync(UscClass entity)
        {
            var allClass = GetAll();
            var targetClassList = await (from c in allClass
                                         where c.ClassId == entity.ClassId
                                         select c.ClassId).ToListAsync();
            var targetClassEntity = _dbContext.ClassInfo.FindAsync(targetClassList);
        }*/

    }
}
