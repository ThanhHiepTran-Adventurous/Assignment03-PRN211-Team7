using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        void createProduct(Product pro);
        void updateProduct(Product pro);
        void deleteProduct(Product product);
        void deleteProductById(int productId);

        Product getProductById(string productId);

        List<Product> getProductByName(string productName);
        List<Product> getProductByUnitPrice(string unitPrice);

        List<Product> getProductByUnitsSlnStock(string unitSlnStock);
    }
}
