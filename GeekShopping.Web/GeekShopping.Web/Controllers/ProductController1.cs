using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController1 : Controller
    {
        private readonly IProductService  _productService;

        public ProductController1(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<ActionResult> ProductIndex()
        {
            var products = _productService.GetAllProduct();
            return View(products);
        }
    }
}
