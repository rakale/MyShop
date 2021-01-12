using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop.Model {
    public sealed class Brand : DefinedEntity<BrandData> {
        public Brand(BrandData d) : base(d) { }
    }


}
