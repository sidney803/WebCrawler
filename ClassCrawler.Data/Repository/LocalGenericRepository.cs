using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClassCrawler.Data.Models;

namespace ClassCrawler.Data.Repository
{
    public class LocalGenericRepository 
    {
        private readonly ClassDbContext _dbContext;

        public LocalGenericRepository()
        {
            //_dbContext = new ClassDbContext();
            _dbContext = new ClassDbContext();
        }

        public async Task CreateAsync(ClassInfo entity)
        {
            //await _dbContext.Set<IEnumerable<ClassInfo>>().AddAsync(entity);
            await _dbContext.ClassInfo.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
