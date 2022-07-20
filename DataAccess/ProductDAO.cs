using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listPro = new List<Product>();
            try
            {
                using(var dbContext = new SalesManagementDBContext())
                {
                    listPro = dbContext.Products.ToList();
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listPro;
        }
        public static Product GetProductById(string proId)
        {
            int _proId = int.Parse(proId);
            Product pro = null;
            try
            {
                using (var context = new SalesManagementDBContext())
                {
                    pro = context.Products.SingleOrDefault(proV => proV.ProductId == _proId);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return pro;
        }
        //------------------------------------------------------------------
        public static void createProduct(Product pro)
        {
            Product product = new Product();
            product = GetProductById(pro.ProductId.ToString());
            if(product == null)
            {
                try
                {
                    using(var dbContext = new SalesManagementDBContext())
                    {
                        dbContext.Products.Add(pro);
                        dbContext.SaveChanges();
                    }
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("ID is alread exists");
            }
        }
        //---------------------------------------------------------------------
        //Update product
        public static void EditProduct(Product pro)
        {
            try
            {
                    SalesManagementDBContext dbContext = new SalesManagementDBContext();
                    dbContext.Products.Update(pro);
                    dbContext.SaveChanges();
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //---------------------------------------------------------------------
        //Delete product by Id
        public static void deleteProductById(int productId)
        {
            try
            {
                using (var context = new SalesManagementDBContext())
                {
                    var product = context.Products.SingleOrDefault(pro => pro.ProductId == productId);
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
