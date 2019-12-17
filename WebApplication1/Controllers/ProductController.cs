using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly ILogger<ProductController> _logger;
        protected StockContext Database { get; set; }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            Database = new StockContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            Database.Dispose();
            base.Dispose(disposing);
        }


        // GET api/product/
        [HttpGet()]
        public IEnumerable<Product> Get()
        {
            return Database.Products.AsEnumerable();
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return Database.Products.FirstOrDefault(x => x.ID == id);
        }

        // POST api/product/
        [HttpPost()]
        public void Post([FromBody]Product product)
        {
            Database.Products.Add(product);
            Database.SaveChanges();
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product)
        {
            product.ID = id;
            Database.Products.Update(product);
            Database.SaveChanges();
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Database.Products.Remove(Database.Products.FirstOrDefault(x => x.ID == id));
            Database.SaveChanges();
        }
    }
}