using Abc.Aids.Random;
using Abc.Data.Shop;
using System;
using System.IO;
using System.Linq;

namespace Abc.Infra {
    public class ShopDbContextInitializer : DbInitializer {

        private static string[] ids = new string[] { "A", "B", "C", "D", "E" };

        public static void Initialize(ShopDbContext db) {
            addCatalogs(db);
            addBrands(db);
            addProducts(db);
            addBuyers(db);
            addBuyerBaskets(db);
            addBuyerOrders(db);
        }

        private static void addBuyerOrders(ShopDbContext db) {
            if (db.Orders.Any()) return;
            db.OrderItems.RemoveRange(db.OrderItems);
            db.SaveChanges();
            foreach (var i in ids) {
                foreach (var j in ids) {
                    addBuyerOrder(i, j, db);
                }
            }
        }

        private static void addBuyerOrder(string i, string j, ShopDbContext db) {
            var orderId = $"Order{i}{j}";
            var orderDate = GetRandom.DateTime(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(-10));
            var orderClosedDate = GetRandom.DateTime(orderDate, DateTime.Now.AddDays(-10));
            addItem(new OrderData {
                Id = orderId,
                BuyerId = buyerId(i),
                From = orderDate,
                To = orderClosedDate
            }, db);
            addOrderItems(orderId, db);
        }

        private static void addOrderItems(string orderId, ShopDbContext db) {
            foreach (var i in ids)
                foreach (var j in ids)
                    addOrderItem(orderId, i, j, db);
        }

        private static void addOrderItem(string orderId, string i, string j, ShopDbContext db) {
            if (!doAddItem()) return;
            addItem(new OrderItemData {
                OrderId = orderId,
                ProductId = $"P{i}{j}",
                Quantity = GetRandom.UInt8(2, 5)
            }, db);
        }

        private static void addBuyerBaskets(ShopDbContext db) {
            if (db.Baskets.Any()) return;
            db.BasketItems.RemoveRange(db.BasketItems);
            db.SaveChanges();
            foreach (var i in ids) {
                foreach (var j in ids) {
                    addBuyerBasket(i, j, db);
                }
            }
        }

        private static void addBuyerBasket(string i, string j, ShopDbContext db) {
            var basketId = $"Basket{i}{j}";
            var basketDate = GetRandom.DateTime(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(-10));
            var basketClosedDate = GetRandom.DateTime(basketDate, DateTime.Now.AddDays(-10));
            addItem(new BasketData {
                Id = basketId,
                BuyerId = buyerId(i),
                From = basketDate,
                To = basketClosedDate
            }, db);
            addBasketItems(basketId, db);
        }

        private static void addBasketItems(string basketId, ShopDbContext db) {
            foreach (var i in ids) {
                foreach (var j in ids) {
                    addBasketItem(basketId, i, j, db);
                }
            }
        }

        private static void addBasketItem(string basketId, string i, string j, ShopDbContext db) {
            if(!doAddItem()) return;
            addItem(new BasketItemData {
                BasketId = basketId,
                ProductId = $"P{i}{j}",
                Quantity = GetRandom.UInt8(2, 5)
            }, db);
        }

        private static bool doAddItem() => GetRandom.UInt16(0, 8) == 3;

        private static void addBuyers(ShopDbContext db) {
            if (db.Buyers.Any()) return;
            foreach (var i in ids) {
                addItem(new BuyerData{
                        Id = buyerId(i),
                        Code = $"GN{i}",
                        Name = $"Given{i} Name{i}",
                        City = $"City{i}",
                        Country = $"Country{i}",
                        Street = $"Street{i}",
                        State = $"State{i}",
                        ZipCode = $"Zip Code{i}"
                }, db);
            }
        }

        private static string buyerId(string i) {
            i = i.ToLower();
            return $"given{i}.name{i}@{i}{i}{i}.{i}{i}";
        }

        private static void addProducts(ShopDbContext db) {
            if (db.Products.Any()) return;
            var dir = Directory.GetCurrentDirectory() + "\\wwwroot\\images";
            var files = Directory.GetFiles(dir);
            foreach (var i in ids) {
                foreach (var j in ids) {
                    var idx = GetRandom.Int32(0, files.Length);
                    addItem(new ProductData {
                        Id = $"P{i}{j}",
                        Code = $"P{i}{j}",
                        Name = $"Product {i}{j}",
                        BrandId = $"B{i}",
                        CatalogId = $"C{j}",
                        Price = GetRandom.UInt8(10, 30),
                        Picture = ConvertToByteArray(files[idx])
                    }, db);
                }
            }
        }

        private static byte[] ConvertToByteArray(string filePath) {
            var file = File.OpenRead(filePath);
            var stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }

        private static void addBrands(ShopDbContext db) {
            if (db.Brands.Any()) return;
            foreach (var i in ids) {
                addItem(new BrandData { Id = $"B{i}", Code = $"B{i}", Name = $"Brand {i}" }, db);
            }
        }

        private static void addCatalogs(ShopDbContext db) {
            if (db.Catalogs.Any()) return;
            foreach (var i in ids) {
                addItem(new CatalogData { Id = $"C{i}", Code = $"C{i}", Name = $"Catalog {i}" }, db);
            }
        }
    }
}
