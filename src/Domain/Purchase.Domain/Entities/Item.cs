using Common.Domain;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase.Domain.Entities
{
    public class Item : EntityBase
    {
        private Item() { }
        internal Item(Guid purchaseId, string name, string description, string barCode, decimal quantity, Money pricePerItem)
        {
            PurchaseId = purchaseId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            BarCode = barCode ?? throw new ArgumentNullException(nameof(barCode));
            Quantity = quantity;
            PricePerItem = pricePerItem ?? throw new ArgumentNullException(nameof(pricePerItem));
        }
        public Guid PurchaseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }
        public decimal Quantity { get; set; }
        public Money PricePerItem { get; set; }
    }
}
