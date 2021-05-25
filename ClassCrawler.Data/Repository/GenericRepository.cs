using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassCrawler.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassCrawler.Data.Repository
{
    public class GenericRepository 
    {
        private readonly ClassMariaDbContext _dbContext;

        public GenericRepository()
        {
            //_dbContext = new ClassDbContext();
            _dbContext = new ClassMariaDbContext();
        }

        public IQueryable<ClassInfo> GetAll()
        {
            var entity = _dbContext.Set<ClassInfo>().AsNoTracking();
            return entity;
        }

        public async Task CreateAsync(ClassInfo entity)
        {
            //await _dbContext.Set<IEnumerable<ClassInfo>>().AddAsync(entity);
            await _dbContext.ClassInfo.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClassInfo entity)
        {
            var allClass = GetAll();
            var targetClassList = await (from c in allClass
                                         where c.ClassId == entity.ClassId
                                         select c.ClassId).ToListAsync();
            var targetClassEntity = _dbContext.ClassInfo.FindAsync(targetClassList);
        }

    }
}
