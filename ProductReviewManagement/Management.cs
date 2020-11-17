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
            foreach(ProductReview product in topRecords)
            {
                Console.WriteLine(product);
            }
        }
    }
}
