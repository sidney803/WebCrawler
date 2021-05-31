using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassCrawler.Data.Repository;
using ClassCrawler.Data.Models;
using ClassCrawler.API.Controllers.Models;

namespace ClassCrawler.API.Controllers
{
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        public ClassController()
        {
           
        }
        
        [Route("GetClass")]
        public IActionResult GetClass()
        {
            GenericRepository<UscClass> uscDbContext = new GenericRepository<UscClass>();
            GenericRepository<University> universityDbContext = new GenericRepository<University>();
            var uscClassInfo = uscDbContext.GetAll().ToList();
            var university = universityDbContext.GetAll()
                .Where(x => x.ClassName == "uscClass")
                .Single();
            //.FirstOrDefault<University>(x => x.ClassName == "uscClass");

            if (uscClassInfo != null && university != null)
            {
                var result = new ClassInfo()
                {
                    University = university,
                    UscClass = uscClassInfo
                };
                return Ok(result);
            }
            else
                return BadRequest();
        }
    }
}
