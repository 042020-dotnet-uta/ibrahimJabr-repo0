using System;
using System.Collections.Generic;
using System.Text;

namespace P0
{
    class OrderProduct
    {
        private int orderProductID;
        public int OrderProductID { get; set; }

        private Order ordeId;
        public Order OrderId { get; set; }

        private Product productId;
        public Product ProductId { get; set; }

        private int productQuantity;
        public int ProductQuantity { get; set; }
    }
}
