namespace ProductReviewManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Management
    {
        /// <summary>Retrieves the top records.</summary>
        /// <param name="products">The products.</param>
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
        /// <summary>Retrieves the selected records.</summary>
        /// <param name="products">The products.</param>
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
        /// <summary>Gives count of reviews for each product.</summary>
        /// <param name="products">The products.</param>
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
        /// <summary>Retrieves the product identifier and reviews.</summary>
        /// <param name="products">The products.</param>
        public void RetrieveProductIdAndReview(List<ProductReview> products)
        {
            var retriveProducts = from product in products
                                  group product by product.ProductID into productGp
                                  select new { productId = productGp.Key, review = String.Join(",",from product in products
                                                                                                   where product.ProductID == productGp.Key
                                                                                                   select product.Review)};
            foreach(var item in retriveProducts)
            {
                Console.WriteLine(item);
            }
        }
    }
}
