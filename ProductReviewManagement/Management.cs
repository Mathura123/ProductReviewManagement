using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProductReviewManagement
{
    public class Management
    {
        public void RetrieveTopRecords(List<ProductReview> products)
        {
            IEnumerable<ProductReview> topRecords = (from product in products
                                                     orderby product.Rating descending
                                                     select product).Take(3);
            foreach (ProductReview product in topRecords)
            {
                Console.WriteLine(product);
            }
        }
        public void RetrieveSelectedRecords(List<ProductReview> products)
        {
            IEnumerable<ProductReview> selectedRecords = from product in products
                                                         where product.Rating > 3 && (product.ProductID == 1 || product.ProductID == 4 || product.ProductID == 9)
                                                         select product;
            foreach (ProductReview product in selectedRecords)
            {
                Console.WriteLine(product);
            }
        }
        public void ReviewCountOnEachProduct(List<ProductReview> products)
        {
            var countByProduct = from product in products
                                  group product by product.ProductID into productGp
                                  select new { productId = productGp.Key, productCount = productGp.Count() };
            foreach (var product in countByProduct)
            {
                Console.WriteLine(product);
            }
        }
    }
}
