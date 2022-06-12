using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorServiceAsync vendorServiceAsync;
        public VendorController(IVendorServiceAsync ser)
        {
            vendorServiceAsync = ser;
        }
        public async Task<IActionResult> Index()
        {
            var result = await vendorServiceAsync.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VendorModel model)
        {
            if (ModelState.IsValid)
            {
                await vendorServiceAsync.AddVendorAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var rgModel = await vendorServiceAsync.GetVendorForEditAsync(id);
            return View(rgModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VendorModel model)
        {
            if (ModelState.IsValid)
            {
                await vendorServiceAsync.UpdateVendorAsync(model);
                ViewBag.IsEdit = true;

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await vendorServiceAsync.DeleteVendorAsync(id);
            return RedirectToAction("Index");
        }
    }
}
