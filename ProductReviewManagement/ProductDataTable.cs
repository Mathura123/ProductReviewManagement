using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace ProductReviewManagement
{
    class ProductDataTable
    {
        private static DataTable table = new DataTable("productDataTable");
        
        /// <summary>Creates the data table from given products list.</summary>
        /// <param name="products">The products list.</param>
        public void CreateDataTable(List<ProductReview> products)
        {
            DataColumn[] columns = { new DataColumn { ColumnName  = "ProductId",DataType = typeof(int)},
                                 new DataColumn { ColumnName  = "UserId",DataType = typeof(int)},
                                 new DataColumn { ColumnName  = "Rating",DataType = typeof(int)},
                                 new DataColumn { ColumnName  = "Review",DataType = typeof(string)},
                                 new DataColumn { ColumnName  = "IsLike",DataType = typeof(bool)}
                                    };
            table.Columns.AddRange(columns);
            foreach (var product in products)
            {
                table.Rows.Add(new object[]{ product.ProductID, product.UserID, product.Rating, product.Review, product.IsLike });
            }
        }
        /// <summary>Shows the table.</summary>
        public static void ShowTable()
        {
            foreach (DataColumn col in table.Columns)
            {
                Console.Write("{0,-14}", col.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.Write("{0,-14}", row[col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
