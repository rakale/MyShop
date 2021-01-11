﻿using Abc.Data.Common;
using System;

namespace Abc.Data.Shop {
    public sealed class OrderData : DefinedEntityData {
        public string BuyerId { get; set; }
        public string Reciever { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }

}
