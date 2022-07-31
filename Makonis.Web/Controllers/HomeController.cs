using Makonis.Web.Models;
using Makonis.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Makonis.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService _customerService;

        public HomeController(ILogger<HomeController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerViewModel customerViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(customerViewModel);
                }
                this._customerService.AddCustomer(customerViewModel);
                TempData["CustomerCreated"] = true;
                return RedirectToAction("CreateCustomer");
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Error in CreateCustomer Post. /n Message: {0} /n StackTrace: {1}", ex.Message, ex.StackTrace);
                return RedirectToAction("Index");
            }
        }
    }
}
