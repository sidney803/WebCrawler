using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClassCrawler.Data.Models;

namespace ClassCrawler.Data.Repository
{
    public class GenericRepository 
    {
        private readonly ClassDbContext _dbContext;

        public GenericRepository()
        {
            _dbContext = new ClassDbContext();
        }

        public async Task CreateAsync(ClassInfo entity)
        {
            await _dbContext.Set<ClassInfo>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
