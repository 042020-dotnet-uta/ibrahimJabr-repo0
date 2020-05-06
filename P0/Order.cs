using System;
using System.Collections.Generic;
using System.Text;

namespace P0
{
    class Order
    {
        private int orderID;
        public int OrderID { get; set; }


        private Customer customer;
        public Customer Customer { get; set; }


        private Store store;         
        public Store Store { get; set; }

        private DateTime orderDate;
        public DateTime OrderDate { get; set; }

        private int orderTotalPrice;
        public int OrderTotalPrice { get; set; }


        //private List<Product> products = new List<Product>();

        //private List<int> productsQuantity = new List<int>();

        /*public String AddItemsToOrder(String PName, int PQuantity)
        {
            if(PQuantity > 10)
            {
                return "unreasonably high product quantities, can not sell that mach"
            }
            Product p = new Product();
            p.ProductName = PName;
            products.Add(p);
            productsQuantity.Add(PQuantity);
            return "succsed";
        }
        public void soldOrder()
        {
            for (int i=0;i<products.Count-1;i++)
            {
                products[i].ProductQuantity = products[i].ProductQuantity - productsQuantity[i];
            }
        }*/
    }
}
