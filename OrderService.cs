using System;
using System.Collections.Generic;
using System.Linq;
using Computer_Parts_Store.Models;

namespace Computer_Parts_Store.Services
{
    public static class OrderService
    {
        private static List<Order> orders = new List<Order>();
        private static int orderCounter = 1;

        // Ініціалізація тестових даних
        static OrderService()
        {
            InitializeTestData();
        }

        private static void InitializeTestData()
        {
            // Тестове замовлення 1
            var order1 = new Order
            {
                OrderNumber = "000001",
                OrderDate = new DateTime(2024, 8, 15, 14, 30, 0),
                CustomerName = "Петренко Петро"
            };
            order1.Items.Add(new Order(
                new Product { Name = "Intel Core i5-12400F", Article = "ART001", Price = 8500.00m },
                2
            ));
            order1.Items.Add(new Order(
                new Product { Name = "NVIDIA RTX 3060", Article = "ART002", Price = 12000.00m },
                1
            ));
            order1.CalculateTotalAmount();
            orders.Add(order1);

            // Тестове замовлення 2
            var order2 = new Order
            {
                OrderNumber = "000002",
                OrderDate = new DateTime(2024, 8, 16, 10, 15, 0),
                CustomerName = "Сидоренко Олена"
            };
            order2.Items.Add(new OrderItem(
                new Product { Name = "AMD Ryzen 5 5600X", Article = "ART003", Price = 7500.00m },
                3
            ));
            order2.Items.Add(new OrderItem(
                new Product { Name = "Kingston RAM 16GB", Article = "ART004", Price = 3000.00m },
                4
            ));
            order2.Items.Add(new OrderItem(
                new Product { Name = "Samsung SSD 1TB", Article = "ART005", Price = 2500.00m },
                2
            ));
            order2.CalculateTotalAmount();
            orders.Add(order2);

            // Тестове замовлення 3
            var order3 = new Order
            {
                OrderNumber = "000003",
                OrderDate = new DateTime(2024, 8, 17, 16, 45, 0),
                CustomerName = "Коваленко Іван"
            };
            order3.Items.Add(new OrderItem(
                new Product { Name = "ASUS Motherboard B550", Article = "ART006", Price = 5000.00m },
                1
            ));
            order3.Items.Add(new OrderItem(
                new Product { Name = "Corsair PSU 650W", Article = "ART007", Price = 3500.00m },
                2
            ));
            order3.CalculateTotalAmount();
            orders.Add(order3);

            orderCounter = 4;
        }

        public static string CreateOrder(string customerName, List<OrderItem> items)
        {
            var order = new Order
            {
                OrderNumber = orderCounter.ToString("D6"),
                OrderDate = DateTime.Now,
                CustomerName = customerName,
                Items = items
            };
            order.CalculateTotalAmount();
            orders.Add(order);
            orderCounter++;
            return order.OrderNumber;
        }

        public static List<Order> GetAllOrders()
        {
            return orders.OrderByDescending(o => o.OrderDate).ToList();
        }

        public static List<Order> GetOrdersByDateRange(DateTime fromDate, DateTime toDate)
        {
            return orders
                .Where(o => o.OrderDate.Date >= fromDate.Date && o.OrderDate.Date <= toDate.Date)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        public static Order GetOrderByNumber(string orderNumber)
        {
            return orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
        }

        public static void ClearAllOrders()
        {
            orders.Clear();
            orderCounter = 1;
        }
    }
    // The issue arises because the `Order` class has duplicate property declarations for `OrderNumber`,
    // `OrderDate`, `CustomerName`, `Items`, and `TotalAmount`. This creates ambiguity when accessing these properties.
    // To fix the issue, remove the duplicate property declarations in the `Order` class definition.

    public class Order
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalAmount { get; set; }

        public int GetTotalItemsCount();
        public void CalculateTotalAmount();
    }
}