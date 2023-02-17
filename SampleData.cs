using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAuthenticationAuthorization.Models;

namespace TaskAuthenticationAuthorization
{
    public class SampleData
    {
        public static void Initialize(ShoppingContext context)
        {
            if (context.Users.Any() || context.Products.Any())
            {
                return;   // DB has been seeded
            }
            context.Roles.AddRange(roles);
            context.Users.AddRange(users);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            context.Products.AddRange(
                    new Product
                    {
                        Name = "Butter",
                        Price = 30.0
                    },
                    new Product
                    {
                        Name = "Banana",
                        Price = 20.50
                    },
                    new Product
                    {
                        Name = "Cola",
                        Price = 9.30
                    }
                );
            context.SaveChanges();
            context.SuperMarkets.AddRange(
                    new SuperMarket
                    {
                        Name = "Wellmart",
                        Address = "Lviv",
                    },
                    new SuperMarket
                    {
                        Name = "Billa",
                        Address = "Odessa",
                    }
                );
            context.SaveChanges();
            context.Orders.AddRange(
                    new Order
                    {
                        CustomerId = 1,
                        SuperMarketId = 1,
                        OrderDate = DateTime.Now,
                     },
                        new Order
                        {
                            CustomerId = 1,
                            SuperMarketId = 1,
                            OrderDate = DateTime.Now,
                         }
                );
            context.SaveChanges();
            context.OrderDetails.AddRange(
                    new OrderDetail
                    {
                        OrderId = 1,
                        ProductId = 1,
                        Quantity = 2
                    },
                        new OrderDetail
                        {
                            OrderId = 2,
                            ProductId = 2,
                            Quantity = 1
                        }
                );
            context.SaveChanges();
            context.Roles.AddRange(
                new Role { Name = "admin" },
                new Role { Name = "buyer" }
            );
            context.SaveChanges();
            context.Users.AddRange(
                new User { Name = "admin", Password = "password", Role = roles[0] },
                new User { Name = "rbuyer", Password = "password", Role = roles[1], BuyerType = BuyerType.Regular },
                new User { Name = "wbuyer", Password = "password", Role = roles[1], BuyerType = BuyerType.Wholesale },
                new User { Name = "gbuyer", Password = "password", Role = roles[1], BuyerType = BuyerType.Golden }
            );
        }

        private readonly static List<Role> roles = new()
        {
            new Role { Name = "admin" },
            new Role { Name = "buyer" }
        };
        private readonly static List<User> users = new()
        {
            new User { Name = "admin", Password = "password", Role = roles[0] },
            new User { Name = "rbuyer", Password = "password", Role = roles[1], BuyerType = BuyerType.Regular },
            new User { Name = "wbuyer", Password = "password", Role = roles[1], BuyerType = BuyerType.Wholesale },
            new User { Name = "gbuyer", Password = "password", Role = roles[1], BuyerType = BuyerType.Golden }
        };

        private readonly static List<Customer> customers = new()
        {
            new Customer
            {
                FirstName = "Ostap",
                LastName = "Bender",
                Address = "Rio de Zhmerinka",
                Discount = Discount.O,
                User = users[1]
            },
            new Customer
            {
                FirstName = "Shura",
                LastName = "Balaganov",
                Address = "Odessa",
                Discount = Discount.R,
                User = users[2]
            },
            new Customer
            {
                FirstName = "Third",
                LastName = "User",
                Address = "City ABC",
                Discount = Discount.V,
                User = users[3]
            }
        };
    }
 }
