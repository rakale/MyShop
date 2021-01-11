using Abc.Aids.Random;
using Abc.Data.Shop;
using System.IO;

namespace Abc.Infra {
    public class ShopDbContextInitializer : DbInitializer {

        private static string[] ids = new string[] { "A", "B", "C", "D", "E" };

        public static void Initialize(ShopDbContext db) {
            addCatalogs(db);
            addBrands(db);
            addProducts(db);
        }

        private static void addProducts(ShopDbContext db) {
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
