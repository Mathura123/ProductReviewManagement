namespace ProductReviewManagement
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management");
            Console.WriteLine("====================================");
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductID=1,UserID=1,Rating=2,Review="Good",IsLike=true},
                new ProductReview(){ProductID=2,UserID=1,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductID=3,UserID=1,Rating=5,Review="Good",IsLike=true},
                new ProductReview(){ProductID=4,UserID=1,Rating=6,Review="Good",IsLike=false},
                new ProductReview(){ProductID=5,UserID=1,Rating=2,Review="nice",IsLike=true},
                new ProductReview(){ProductID=8,UserID=1,Rating=1,Review="bas",IsLike=true},
                new ProductReview(){ProductID=8,UserID=1,Rating=1,Review="Good",IsLike=false},
                new ProductReview(){ProductID=8,UserID=1,Rating=9,Review="nice",IsLike=true},
                new ProductReview(){ProductID=2,UserID=1,Rating=10,Review="nice",IsLike=true},
                new ProductReview(){ProductID=9,UserID=1,Rating=8,Review="nice",IsLike=true},
                new ProductReview(){ProductID=11,UserID=1,Rating=3,Review="nice",IsLike=true}
            };
            //foreach(ProductReview product in productReviewList)
            //{
            //    Console.WriteLine(product);
            //}
            Management objManagement = new Management();
            //objManagement.RetrieveTopRecords(productReviewList);
            //objManagement.RetrieveSelectedRecords(productReviewList);
            //objManagement.ReviewCountOnEachProduct(productReviewList);
            //objManagement.RetrieveProductIdAndReview(productReviewList);
            //objManagement.SkipFiveRecords(productReviewList);
            objManagement.ProductIdAndReviewUsingMethodSyntax(productReviewList);
        }
    }
}
