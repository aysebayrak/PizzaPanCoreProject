﻿using Microsoft.AspNetCore.Mvc;
using PizzaPan.BussinesLayer.Abstract;
using PizzaPan.EntityLayer.Concrate;

namespace PizzaPan.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {

            _productService = productService;   
        }

        public IActionResult Index()
        {
            //var values = _productService.TGetList();
            var values = _productService.TGetProductsWithCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product prodcuct)
        {
            _productService.TInsert(prodcuct);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {

            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _productService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product);
            return RedirectToAction("Index");

        }
    }
}
