using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P0
{
    class Program
    {
        public static DB db = new DB();
        static void Main(string[] args)
        {
        here:
          string input;
            Customer customer = null;
            Console.WriteLine(" Do you have an account (y/n), you can enter any key to exit");
            input = Console.ReadLine();
            if(input == "y")
            {
                
                Console.WriteLine(" Enter your username");
                string userN = Console.ReadLine();
                Console.WriteLine(" Enter your Password");
                string password = Console.ReadLine();
                customer = LogInu(userN,password);
            }
            else if(input =="n")
            {
                Console.WriteLine(" Would you like to sign-up (y/n), you can enter any key to exit");
                input = Console.ReadLine();
                if(input =="y")
                {
                    customer = SighnUp();
                }
            }
            if (customer != null && customer.IsAdmen == true)
            {
                Console.WriteLine($" To search user by name(sun)\n To get all orders in one store(aos)\n To exit enter any other key");
                bool b = true;
                while (b)
                {
                    input = Console.ReadLine();
                    if (input == "sun")
                    {
                        Console.WriteLine(" Enter the customer name");
                        string cname = Console.ReadLine();
                        searchByUserName( cname);

                        Console.WriteLine($" To search user by name(sun)\n To get all orders in one store(aos)\n To exit enter any other key");
                    }
                    else if (input == "aos")
                    {
                        var stores = db.Stores;
                        foreach (Store s in stores)
                        {
                            Console.WriteLine(s.StoreID+" "+s.StoreLocation);
                        }
                        allorstor:
                        Console.WriteLine(" Enter the store id from the above list");
                        try { 
                        int sn = int.Parse(Console.ReadLine());
                        allOrdersByLocation(sn);
                        Console.WriteLine($" To search user by name(sun)\n To get all orders in one store(aos)\n To exit enter any other key");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("you have enterd string");
                            goto allorstor;
                        }
                    }
                    else
                    {
                        b = false;
                    }
                }
            }
            else if (customer != null && customer.IsAdmen == false)
            {
                Console.WriteLine($" To change your store enter(s)\n To make new order enter(o)\n To see your order History enter (oh)\n To see see specific order enter (so)\n To exit enter any other key");
                bool b = true;
                while(b)
                {
                    input = Console.ReadLine();
                    if (input == "s")
                    {
                        customer.Store = choiceAStore();
                        db.SaveChanges();
                        Console.WriteLine(" You have successfully changed your store");
                        Console.WriteLine($" To change your store enter(s)\n To make new order enter(o)\n To see your order History enter (oh)\n To see see specific order enter (so)\n To exit enter any other key");
                    }
                    else if (input == "o")
                    {
                        makeAnOrder(customer);
                        Console.WriteLine(" You have successfully made a new order");
                        Console.WriteLine($" To change your store enter(s)\n To make new order enter(o)\n To see your order History enter (oh)\n To see see specific order enter (so)\n To exit enter any other key");
                    }
                    else if (input == "oh")
                    {
                        getOrderHestory(customer);
                        Console.WriteLine($" To change your store enter(s)\n To make new order enter(o)\n To see your order History enter (oh)\n To see see specific order enter (so)\n To exit enter any other key");
                    }
                    else if(input == "so")
                    {

                        var ord = db.Orders.Where(o => o.Customer.CustomerID == customer.CustomerID);
                        foreach(Order o in ord)
                        {
                            Console.WriteLine(o.OrderID);
                        }
                        spaorder:
                        Console.WriteLine(" Enter the order number from the above list");
                        try { 
                        int on = int.Parse(Console.ReadLine());
                        getSOrderHestory(on, customer);
                        Console.WriteLine($" To change your store enter(s)\n To make new order enter(o)\n To see your order History enter (oh)\n To see see specific order enter (so)\n To exit enter any other key");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("you enterd string");
                            goto spaorder;
                        }
                    }
                    else
                    {
                        b = false;
                    }
                }
            }
            Console.WriteLine(" Do you wont to change account(y/n), you can enter any key to exit");
            input = Console.ReadLine();
            if(input == "y")
            {

                goto here;
            }
            Console.WriteLine(" Visit as again");
        }



        public static Customer LogInu(string userN, string password)
        {
            
            string input;
            var customer = db.Customers.Where(c => c.UserName == userN && c.Passowerd == password).Include(a=> a.Store).FirstOrDefault();
            if (customer == null)
            {
                Console.WriteLine(" The username or the password is wrong, would you like to try again(y/n)");
                input = Console.ReadLine();
                if (input == "y")
                {
                    Console.WriteLine(" Enter your username");
                    userN = Console.ReadLine();
                    Console.WriteLine(" Enter your Password");
                    password = Console.ReadLine();
                    return LogInu(userN, password);
                    
                }
                else
                {
                    Console.WriteLine(" Do yo wont to sign-in (y/n)");
                    input = Console.ReadLine();
                    if(input =="y")
                    {
                       return SighnUp();
                    }
                    else
                    {
                        return customer;
                    }
                    
                }
            }
            else 
            {
                return customer;
            }
            
        }


        public static Customer SighnUp()
        {
            Customer c = new Customer();
            Console.WriteLine(" Enter your username");
            c.UserName = Console.ReadLine();
            bool b = true;
            while (b)
            {
                Console.WriteLine(" Enter your Password");
                string p1 = Console.ReadLine();
                Console.WriteLine(" Re-enter your Password");
                string p2 = Console.ReadLine();
                if (p1 == p2)
                {
                    c.Passowerd = new string(p1);
                    b = false;
                }
                else
                {
                    Console.WriteLine(" The Password did not match re-enter");
                }
            }
            Console.WriteLine(" Enter your First Name");
            c.FirstName = Console.ReadLine();
            Console.WriteLine(" Enter your Last Name");
            c.LasttName = Console.ReadLine();
            c.Store = choiceAStore();
           

            
            var customers = db.Customers;
            db.Add(c);
            db.SaveChanges();
            return c;
        }



        public static Store choiceAStore()
        {
            Console.WriteLine(" This is a list of the stores if you did not choose one a default store will be assign to you");
            var stores = db.Stores.OrderBy(s => s.StoreID);
            foreach (Store s in stores)
            {
                Console.Write($" If you wont {s.StoreLocation} to be your store enter (y)");
                string d = Console.ReadLine();
                if (d == "y")
                {
                    return s;
                }
                if (s.StoreID == 5)
                {
                    return  s;
                }
               
            }
            return null;
        }


        public static void makeAnOrder(Customer c)
        {
            List<OrderProduct> ordersproducts = new List<OrderProduct>();
            OrderProduct op = null;
            string input;
            int sum=0;
            var storeproducs = db.StoreProducts.Where(b => b.Store.StoreID == c.Store.StoreID).Include(a => a.Product);
            foreach (StoreProduct sp in storeproducs)
            {
                Console.WriteLine($" Product Id: {sp.Product.ProductID}   Product name: {sp.Product.ProductName}\n Product description: {sp.Product.ProductDis}\n Product price: {sp.Product.ProductPrice}");
            notRight:
                Console.WriteLine(" Do you wont to buy this item, if yes enter the quantity otherwise enter(n)");
                notRight1:
                input = Console.ReadLine();
               if(input != "n") { 
                    try
                    {
                        int pq = int.Parse(input);
                        if(pq > 10)
                        {
                            Console.WriteLine($" {pq} Is to mach choose number less than 10");
                            goto notRight1;
                        }
                        var sproduct = db.StoreProducts.Where(s => s.Product.ProductID == sp.Product.ProductID).FirstOrDefault();
                        if(sproduct.ProductQuantity - pq < 0)
                        {
                            Console.WriteLine($" We have {sproduct.ProductQuantity} of {sp.Product.ProductName} please enter number less than {sproduct.ProductQuantity + 1}");
                            goto notRight1;
                        }
                        sum = sum+(sp.Product.ProductPrice * pq);
                        op = new OrderProduct();
                        op.ProductId = sp.Product;
                        op.ProductQuantity = pq;
                        ordersproducts.Add(op);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine($" {input} is not a number");
                        goto notRight;
                    }
                }
            }
            if (ordersproducts.Count > 0)
            {
                Order o = new Order();
                o.OrderTotalPrice = sum;
                o.OrderDate = DateTime.Now;
                o.Store = c.Store;
                o.Customer = c;
                var orders = db.Orders;
                db.Add(o);
                db.SaveChanges();

                var orders1 = db.Orders.OrderByDescending(i => i.OrderID).FirstOrDefault();
                foreach(OrderProduct ops in ordersproducts)
                {   
                 
                    var orderprod = db.OrderProducts;
                    ops.OrderId = orders1;
                    db.Add(ops);
                    db.SaveChanges();
                    var sproduct = db.StoreProducts.Where(s => s.Product.ProductID == op.ProductId.ProductID).FirstOrDefault();
                    sproduct.ProductQuantity = sproduct.ProductQuantity - op.ProductQuantity;
                    db.SaveChanges();
                }
                Console.WriteLine($" You have successfully made an order, you paid {sum}");
            }           

        }


        public static void getOrderHestory(Customer c)
        {
            int sum = 0;
            var orderP = db.OrderProducts.Where(o => o.OrderId.Customer.CustomerID == c.CustomerID).Include(o => o.OrderId).Include(p=>p.ProductId).Include(s=> s.OrderId.Store);
            if(orderP.Any() == false)
            {
                Console.WriteLine(" you do not have any order");
            }
            else { 
            foreach(OrderProduct op in orderP) 
            {
                Console.WriteLine($" Order ID: {op.OrderId.OrderID} Order date: {op.OrderId.OrderDate} Order price: {op.OrderId.OrderTotalPrice}\n Product ID: {op.ProductId.ProductID} Product name: {op.ProductId.ProductName} Product quantity {op.ProductQuantity}\n Product price: {op.ProductId.ProductPrice}\n Store Id {op.OrderId.Store.StoreID} Store location {op.OrderId.Store.StoreLocation}\n");
                sum = sum + (op.ProductId.ProductPrice* op.ProductQuantity);
            }
            Console.WriteLine($" All orders cost: {sum}");
        }
        }

        public static void getSOrderHestory(int ordernum, Customer c)
        {
            var orderP = db.OrderProducts.Where(o => o.OrderId.Customer.CustomerID == c.CustomerID && o.OrderId.OrderID == ordernum).Include(o => o.OrderId).Include(p => p.ProductId).Include(s => s.OrderId.Store);
            if (orderP.Any() == false)
            {
                Console.WriteLine(" The order id does not exist for this customer");
            }
            else
            {
                foreach (OrderProduct op in orderP)
                {
                    Console.WriteLine($" Order ID: {op.OrderId.OrderID} Order date: {op.OrderId.OrderDate} Order price: {op.OrderId.OrderTotalPrice}\n Product ID: {op.ProductId.ProductID} Product name: {op.ProductId.ProductName} Product quantity {op.ProductQuantity}\n Product price: {op.ProductId.ProductPrice}\n Store Id {op.OrderId.Store.StoreID} Store location {op.OrderId.Store.StoreLocation}\n");
                    
                }
            }
        }

        public static void searchByUserName(string cname)
        {
            var customer = db.Customers.Where(c => c.FirstName+" "+c.LasttName == cname).Include(s=>s.Store).FirstOrDefault();
            if(customer != null)
            {
                Console.WriteLine($" user id: {customer.CustomerID} user name: {customer.UserName} customer name: {customer.FirstName} {customer.LasttName} user Store: {customer.Store.StoreLocation}");
            }
            else 
            {
                Console.WriteLine(" There is no user with this name, would you like to try again(y/n");
                string input = Console.ReadLine();
                if(input == "y")
                {
                    Console.WriteLine(" Enter the customer name");
                    cname = Console.ReadLine();
                    searchByUserName(cname);
                }

            }
        }

        public static void allOrdersByLocation(int storeId)
        {
            var orderP = db.OrderProducts.Where(o => o.OrderId.Store.StoreID == storeId).Include(o => o.OrderId).Include(p => p.ProductId).Include(c=>c.OrderId.Customer);
            if (orderP.Any() == false)
            {
                Console.WriteLine(" The store id does not exist for this customer");
            }
            else
            {
                foreach (OrderProduct op in orderP)
                {
                Console.WriteLine($" Order ID: {op.OrderId.OrderID} Order date: {op.OrderId.OrderDate} Order price: {op.OrderId.OrderTotalPrice}\n Product ID: {op.ProductId.ProductID} Product name: {op.ProductId.ProductName} Product quantity {op.ProductQuantity}\n Product price: {op.ProductId.ProductPrice}\n Customer Id {op.OrderId.Customer.CustomerID} user name {op.OrderId.Customer.UserName} customer name{op.OrderId.Customer.FirstName} {op.OrderId.Customer.LasttName}\n");
                }
            }
        }
    }
      
}

