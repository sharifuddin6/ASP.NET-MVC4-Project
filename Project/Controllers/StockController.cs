using System;
using System.Web.Http;
using Project.Domain;
using Project.Domain.Repositories;

namespace Project.Controllers
{
    [RoutePrefix("api/stock")]
    public class StockController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public StockController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // PUT api/<controller>/
        [HttpPost]
        public void AddProduct(Product product)
        {
            product.Id = _productRepository.GetProductCount();
            _productRepository.AddProduct(product);
        }

        //// GET api/<controller>
        //[HttpGet]
        //[Route("")]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //[HttpGet]
        //[Route("{id:int}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}