using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public abstract class ItemProduct<TData> : Entity<TData> 
        where TData : ItemProductData, new() {
        protected ItemProduct(TData d) : base(d) { }
        
        public string ProductId => Data?.ProductId ?? Unspecified;
        public Product Product => new GetFrom<IProductsRepository, Product>().ById(ProductId);
        public int Quantity => Data?.Quantity ?? UnspecifiedInteger;
        public decimal TotalPrice => Product?.Price ?? 0M * Quantity;
    }
}
