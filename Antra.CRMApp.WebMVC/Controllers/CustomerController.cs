using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServiceAsync CustomerServiceAsync;
        private readonly IRegionServiceAsync regionServiceAsync;
        public CustomerController(ICustomerServiceAsync ser, IRegionServiceAsync reg)
        {
            CustomerServiceAsync = ser;
            regionServiceAsync = reg;
        }
        public async Task<IActionResult> Index()
        {
            var result = await CustomerServiceAsync.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                await CustomerServiceAsync.AddCustomerAsync(model);
                return RedirectToAction("Index");
            }

            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var customerModel = await CustomerServiceAsync.GetCustomerForEditAsync(id);

            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(customerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerModel model)
        {
            ViewBag.IsEdit = false;
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await CustomerServiceAsync.UpdateCustomerAsync(model);
                ViewBag.IsEdit = true;

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await CustomerServiceAsync.DeleteCustomerAsync(id);
            return RedirectToAction("Index");
        }
    }
}
