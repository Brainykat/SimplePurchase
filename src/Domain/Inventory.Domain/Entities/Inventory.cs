using Common.Domain;
using Common.Domain.ValueObjects;
using Inventory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    public class Inventory : EntityBase
    {
        public static Inventory Create(Guid purchaseId, Guid userId, string comments) =>
            new Inventory(purchaseId, userId, comments);
        public void AddItem(string name, string description, string barCode,
            decimal quantity, DateTime expirery, bool isPOSItem, ItemType itemType,Money sellingPrice) =>
            Items.Add(new Item(this.Id, name, description, barCode, quantity, expirery, isPOSItem, 
                itemType, sellingPrice));
        private Inventory() { }
        private Inventory(Guid purchaseId, Guid userId, string comments)
        {
            if(string.IsNullOrWhiteSpace(comments)) throw new ArgumentNullException(nameof(comments));
            PurchaseId = purchaseId;
            UserId = userId;
            AddedOn = DateTimeRangeExtensions.GetDate();
            Comments = comments;
            Items = new List<Item>();
        }

        public Guid UserId { get; set; }
        public Guid PurchaseId { get; set; }
        public DateTime AddedOn { get; set; }
        public string Comments { get; set; }
        public List<Item> Items { get; set; }
    }
}
