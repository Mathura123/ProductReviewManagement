using System;
using System.Collections.Generic;
using System.Text;

namespace ProductReviewManagement
{
    public class ProductReview
    {
        public int ProductID{ get; set; }
        public int UserID{ get; set; }
        public double Rating{ get; set; }
        public string Review{ get; set; }
        public bool IsLike{ get; set; }

        public override string ToString()
        {
            return $"ProductID : {ProductID},UserId : {UserID},Rating : {Rating},Review : {Review},IsLike : {IsLike}";
        }
    }
}
