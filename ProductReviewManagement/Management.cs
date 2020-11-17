using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProductReviewManagement
{
    public class Management
    {
        /// <summary>Retrieves the top records.</summary>
        /// <param name="products">The products.</param>
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
        /// <summary>Retireves selected records.</summary>
        /// <param name="listProductReview">The list product review.</param>
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordData = from productReviews in listProductReview
                             where (productReviews.ProductID == 1 || productReviews.ProductID == 4 || productReviews.ProductID == 9)
                             && productReviews.Rating > 3
                             select productReviews;
            foreach (var product in recordData)
            {
                Console.WriteLine(product);
            }
        }
    }
}
