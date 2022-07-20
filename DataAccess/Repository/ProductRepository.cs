using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts() => ProductDAO.GetProducts();


        public void createProduct(Product pro) => ProductDAO.createProduct(pro);


        public void updateProduct(Product pro) => ProductDAO.EditProduct(pro);
      

        public void deleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void deleteProductById(int productId) => ProductDAO.deleteProductById(productId);
       

        public Product getProductById(string productId) => ProductDAO.GetProductById(productId);
        

        public List<Product> getProductByName(string productName)
        {
            throw new NotImplementedException();
        }

        public List<Product> getProductByUnitPrice(string unitPrice)
        {
            throw new NotImplementedException();
        }

        public List<Product> getProductByUnitsSlnStock(string unitSlnStock)
        {
            throw new NotImplementedException();
        }

       
    }
}
