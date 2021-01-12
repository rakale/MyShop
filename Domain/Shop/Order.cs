using Abc.Aids.Reflection;
using Abc.Data.Shop;
using Abc.Domain.Common;
using System;
using System.Collections.Generic;

namespace Abc.Domain.Shop {
    public sealed class Order : BuyerProducts<OrderData> {
        private readonly string orderId = GetMember.Name<OrderItemData>(x => x.OrderId);        
        public Order(OrderData d) : base(d) { }
        public string Street => Data?.Street ?? Unspecified;
        public string City => Data?.City ?? Unspecified;
        public string State => Data?.State ?? Unspecified;
        public string Country => Data?.Country ?? Unspecified;
        public string ZipCode => Data?.ZipCode ?? Unspecified;
        public IReadOnlyList<OrderItem> Items =>
            new GetFrom<IOrderItemsRepository, OrderItem>().ListBy(orderId, Id);

        public decimal TotalPrice {
            get {
                var sum = decimal.Zero;
                foreach (var i in Items) sum += i.TotalPrice;
                return sum;
            }
        }
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
