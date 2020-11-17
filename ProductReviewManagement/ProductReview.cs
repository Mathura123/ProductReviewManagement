using System;
using System.Data;

namespace ProductReviewManagement
{
    public class ProductReview
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public bool IsLike { get; set; }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"ProductID : {ProductID},UserId : {UserID},Rating : {Rating},Review : {Review},IsLike : {IsLike}";
        }

        /// <summary>Performs an explicit conversion from <see cref="DataRow" /> to <see cref="ProductReview" />.</summary>
        /// <param name="v">The v.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ProductReview(DataRow v)
        {
            return new ProductReview
            {
                ProductID = v.Field<int>("ProductId"),
                UserID = v.Field<int>("UserId"),
                Rating = v.Field<int>("Rating"),
                Review = v.Field<string>("Review"),
                IsLike = v.Field<bool>("IsLike")
            };
        }
    }
}
