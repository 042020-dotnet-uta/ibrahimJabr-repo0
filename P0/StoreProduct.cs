using System;
using System.Collections.Generic;
using System.Text;

namespace P0
{
    class StoreProduct
    {
        private int storeProductID;
        public int StoreProductID { get; set; }

        private Store store;
        public Store Store { get; set; }

        private Product product;
        public Product Product { get; set; }

        private int productQuantity;
        public int ProductQuantity { get; set; }
    }
}
