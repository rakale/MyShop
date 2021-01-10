using Abc.Aids.Random;
using Abc.Data.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Infra {
    public class ShopDbContextInitializer: DbInitializer{

        private static string[] ids = new string[] { "A", "B", "C", "D", "E" };

        public static void Initialize(ShopDbContext db) {
            addCatalogs(db);
            addBrands(db);
            addProducts(db);
        }

        private static void addProducts(ShopDbContext db) {
            foreach (var i in ids) {
                foreach (var j in ids) {
                    addItem(new ProductData {
                        Id = $"P{i}{j}", Code = $"P{i}{j}",
                        Name = $"Product {i}{j}",
                        CatalogBrandId = $"B{i}",
                        CatalogTypeId = $"C{j}",
                        Price = GetRandom.UInt8(10,30)
                    }, db);;
                }
            }
        }

        private static void addBrands(ShopDbContext db) {
            foreach (var i in ids) {
                addItem(new BrandData { Id = $"B{i}", Code = $"B{i}", Name = $"Brand {i}" }, db);
            }
        }

        private static void addCatalogs(ShopDbContext db) {
            foreach (var i in ids) {
                addItem(new CatalogData { Id = $"C{i}", Code = $"C{i}", Name = $"Catalog {i}" }, db);
            }
        }
    }
}
