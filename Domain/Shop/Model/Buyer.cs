using Abc.Data.Shop;
using Abc.Domain.Common;
using System;

namespace Abc.Domain.Shop.Model {
    public sealed class Buyer : NamedEntity<BuyerData> {
        public Buyer(BuyerData d) : base(d) { }
        public string Street => Data?.Street ?? Unspecified;
        public string City => Data?.City ?? Unspecified;
        public string State => Data?.State ?? Unspecified;
        public string Country => Data?.Country ?? Unspecified;
        public string ZipCode => Data?.ZipCode ?? Unspecified;
        public string Address => address();

        private string address() => add(zipCode, Country);
        private string zipCode() => add(state, ZipCode);
        private string state() => add(city, State);
        private string city() => add(street, City);
        private string street() => (isUnspecified(Street) ? Unspecified : Street).Trim();
        private static string add(Func<string> head, string tail) =>
            (isUnspecified(tail) ? head() : $"{head()} {tail}").Trim();
    }
}
