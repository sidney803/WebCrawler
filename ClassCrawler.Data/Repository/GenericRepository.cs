using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClassCrawler.Data.Models;

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

        public async Task CreateAsync(ClassInfo entity)
        {
            //await _dbContext.Set<IEnumerable<ClassInfo>>().AddAsync(entity);
            await _dbContext.ClassInfo.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
