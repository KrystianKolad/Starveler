using System;
using System.Collections.Generic;

namespace Starveler.Common.Entities
{
    public class Order : BasicEntity
    {
        public Address Address { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Comments { get; set; }
        public IEnumerable<Dish> OrderItems { get; set; }
    }
}