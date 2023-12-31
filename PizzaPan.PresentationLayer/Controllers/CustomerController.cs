﻿using Microsoft.AspNetCore.Mvc;
using PizzaPan.BussinesLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;

namespace PizzaPan.PresentationLayer.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService; 

        }
        public IActionResult Index()
        {
            var values = _customerService.TGetList();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
           _customerService.TInsert(customer);
            return RedirectToAction("Index");
        }



        public IActionResult DeleteCustomer(int id)
        {
            var value = _customerService.TGetById(id);
            _customerService.TDelete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = _customerService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerService.TUpdate(customer);
            return RedirectToAction("Index");

        }
    }
}
