using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.WebMVC.Models;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServiceAsync productServiceAsync;
        private readonly ICategoryServiceAsync categoryServiceAsync;
        private readonly IVendorServiceAsync vendorServiceAsync;

        public ProductController(IProductServiceAsync productServiceAsync, ICategoryServiceAsync categoryServiceAsync, IVendorServiceAsync vendorServiceAsync)
        {
            this.productServiceAsync = productServiceAsync;
            this.categoryServiceAsync = categoryServiceAsync;
            this.vendorServiceAsync = vendorServiceAsync;
        }

        //public IActionResult Index()
        //{
        //    List<Product> products = new List<Product>();
        //    products.Add(new Product() { Id=1, Name="Laptop", Color="Silver", Price=2000});
        //    products.Add(new Product() { Id = 2, Name = "Iphone", Color = "Black", Price = 1000 });
        //    products.Add(new Product() { Id = 3, Name = "Samsung Galaxy", Color = "Blue", Price = 900 });
        //    products.Add(new Product() { Id = 4, Name = "Chair", Color = "Wooden", Price = 120 });
        //    products.Add(new Product() { Id = 5, Name = "Table", Color = "White", Price = 250 });

        //    ViewData["Title"] = "Product/Index";
        //    return View(products);
        //}

        public async Task<IActionResult> Index()
        {
            var collection = await productServiceAsync.GetAllAsync();
            if (collection != null)
                return View(collection);

            List<ProductResponseModel> model = new List<ProductResponseModel>();
            return View(model);
        }
        public IActionResult Detail()
        {
            ViewData["Title"] = "Product/Details";
            return View("explain");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ctCollection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(ctCollection, "Id", "Name");

            var vdCollection = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(vdCollection, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await productServiceAsync.AddProductAsync(model);
                return RedirectToAction("Index");
            }
            var ctCollection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(ctCollection, "Id", "Name");

            var vdCollection = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(vdCollection, "Id", "Name");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var prModel = await productServiceAsync.GetProductForEditAsync(id);
            var ctCollection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(ctCollection, "Id", "Name");

            var vdCollection = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(vdCollection, "Id", "Name");
            return View(prModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductRequestModel model)
        {
            ViewBag.IsEdit = false;
            var ctCollection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(ctCollection, "Id", "Name");

            var vdCollection = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(vdCollection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await productServiceAsync.UpdateProductAsync(model);
                ViewBag.IsEdit = true;

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await productServiceAsync.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
    }
}
