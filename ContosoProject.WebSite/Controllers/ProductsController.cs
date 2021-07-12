using ContosoCrafts.WebSite.Services;
using ContosoProject.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoProject.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }
        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        } 

        [Route("Rate")]
        [HttpPost]
        public ActionResult Get([FromQuery] string productId,[FromQuery] int rating)
        {
            ProductService.AddRating(productId,rating);
            return Ok();
        }
    }
}
