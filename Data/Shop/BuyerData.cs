using Abc.Data.Common;


namespace Abc.Data.Shop {
    public sealed class BuyerData : NamedEntityData {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
