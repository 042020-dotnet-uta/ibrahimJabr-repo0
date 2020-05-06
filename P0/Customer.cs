using System;
using System.Collections.Generic;
using System.Text;

namespace P0
{
    class Customer
    {
        private int customerID;
        public int CustomerID { get; set; }

        private string userName;
        public string UserName { get; set; }

        private string firstName;
        public string FirstName { get; set; }


        private string lasrtName;
        public string LasttName { get; set; }

        private string passowerd;
        public string Passowerd { get; set; }

        private Store store;
        public Store Store { get; set; }

        private bool isAdmen;
        public bool IsAdmen { get; set; }

    }
}
