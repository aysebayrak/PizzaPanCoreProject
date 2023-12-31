﻿using Microsoft.AspNetCore.Mvc;
using PizzaPan.BussinesLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;

namespace PizzaPan.PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.TGetList();
            return View(values);
           
        }


        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee )
        {
            _employeeService.TInsert(employee);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteEmployee(int id)
        {
            var value = _employeeService.TGetById(id);
           _employeeService.TDelete(value);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var value = _employeeService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            _employeeService.TUpdate(employee);
            return RedirectToAction("Index");

        }




    }
}
