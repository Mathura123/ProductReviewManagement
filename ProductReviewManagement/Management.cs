namespace ProductReviewManagement
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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
                                  select new
                                  {
                                      productId = productGp.Key,
                                      review = String.Join(",", from product in products
                                                                where product.ProductID == productGp.Key
                                                                select product.Review)
                                  };
            foreach (var item in retriveProducts)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>Skips the five records and retrieve else records.</summary>
        /// <param name="products">The products.</param>
        public void SkipFiveRecords(List<ProductReview> products)
        {
            IEnumerable<ProductReview> skippedRecords = (from product in products
                                                         orderby product.Rating descending
                                                         select product).Skip(5);
            foreach (ProductReview product in skippedRecords)
            {
                Console.WriteLine(product);
            }
        }
        /// <summary>Retrieves the product identifier and reviews.</summary>
        /// <param name="products">The products.</param>
        public void ProductIdAndReviewUsingMethodSyntax(List<ProductReview> products)
        {
            var retriveProducts = products.GroupBy(x => x.ProductID).Select(x => new
            {
                productId = x.Key,
                reviews = String.Join(",", x.Select(z => z.Review))
            });
            foreach (var item in retriveProducts)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>Retrieves the records from DataTable with true isLike.</summary>
        public void RetrieveRecordsFromDataTableWithIsLike()
        {
            IEnumerable<DataRow> isLikeProducts = from product in ProductDataTable.table.AsEnumerable()
                                                  where product.Field<bool>("IsLike") == true
                                                  select product;
            foreach(DataRow row in isLikeProducts)
            {
                Console.WriteLine((ProductReview)row);
            }
        }
        /// <summary>Gets the average ratings for every product.</summary>
        public void GetAvgRatings()
        {
            var avgRatings = from product in ProductDataTable.table.AsEnumerable()
                             group product by product.Field<int>("ProductId") into productGrp
                             select new { productId = productGrp.Key, average = Math.Round(productGrp.Average(x=>x.Field<int>("Rating")),2) };
            foreach(var ratings in avgRatings)
            {
                Console.WriteLine(ratings);
            }
        }
        /// <summary>Gets the products with nice review.</summary>
        public void GetProductsWithNiceReview()
        {
            var avgRatings = from product in ProductDataTable.table.AsEnumerable()
                             where product.Field<string>("Review").ToLower()== "nice"
                             select product;
            foreach (var ratings in avgRatings)
            {
                Console.WriteLine((ProductReview)ratings);
            }
        }
    }
}
