using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;

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
                return NotFound();
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
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var pro = _productRepository.getProductById(id.ToString());
            if(pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _productRepository.deleteProductById(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public ActionResult Search()
        {
            string search = Request.Form["txtSearch"];
            string type = Request.Form["type"];
            if(search != null && type.Equals("1"))
            {
                List<Product> listProduct = _productRepository.getProductByName(search);
                return View(listProduct);
            }else if(search != null && type.Equals("2"))
            {
                List<Product> listProduct = _productRepository.getProductByUnitPrice(search);
                return View(listProduct);
            }else if (search != null && type.Equals("3"))
            {
                List<Product> listProduct = _productRepository.getProductByUnitsSlnStock(search);
                return View(listProduct);
            }      
            else
            {
                return View();
            }
            
        }
    }
}
