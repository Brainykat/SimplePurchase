using Common.Domain;
using Common.Domain.ValueObjects;
using Inventory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    public class Item : EntityBase
    {
        private Item() { }
        internal Item(Guid inventoryId, string name, string description, string barCode, 
            decimal quantity, DateTime expirery, bool isPOSItem, ItemType itemType, Money sellingPrice)
        {
            InventoryId = inventoryId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            BarCode = barCode ?? throw new ArgumentNullException(nameof(barCode));
            Quantity = quantity;
            Expirery = expirery;
            IsPOSItem = isPOSItem;
            ItemType = itemType;
            SellingPrice = sellingPrice?? throw new ArgumentNullException(nameof(sellingPrice));
        }
        public Guid InventoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Expirery { get; set; }
        public bool IsPOSItem { get; set; }
        public ItemType ItemType { get; set; }
        public Money SellingPrice { get; set; }
    }
}
