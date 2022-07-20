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
    }
}
