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
       

        public void createProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void updateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void deleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void deleteProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Product getProductById(string productId)
        {
            throw new NotImplementedException();
        }

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
