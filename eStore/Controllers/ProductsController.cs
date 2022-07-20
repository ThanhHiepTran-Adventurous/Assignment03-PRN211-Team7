using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;
using DataAccess.Repository;
using System;

namespace eStore.Controllers
{
    public class ProductsController : Controller
    {
        IProductRepository _productRepository = null;

        public ProductsController() => _productRepository = new ProductRepository();

        // GET: ProductsController
        public ActionResult Index()
        {
            var proList = _productRepository.GetProducts();
            return View(proList);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = _productRepository.getProductById(id);
            if(product == null)
            {
                return NotFound(
            }
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productRepository.createProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(product);
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = _productRepository.getProductById(id.ToString());
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product pro)
        {
            try
            {
                if (id != pro.ProductId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _productRepository.updateProduct(pro);   
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
