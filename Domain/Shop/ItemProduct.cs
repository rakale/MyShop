using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public abstract class ItemProduct<TData> : Entity<TData> 
        where TData : ItemProductData, new() {
        protected ItemProduct(TData d) : base(d) { }
        
        public string ProductId => Data?.ProductId ?? Unspecified;
        public Product Product => new GetFrom<IProductsRepository, Product>().ById(ProductId);
    }
}
