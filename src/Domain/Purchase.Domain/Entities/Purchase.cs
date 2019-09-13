using Common.Domain;
using Common.Domain.ValueObjects;
using Purchase.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase.Domain.Entities
{
    public class Purchase : EntityBase
    {
        private Purchase() { }
        public static Purchase Create(Guid initiator, Guid supplierId) =>
            new Purchase(initiator, supplierId);
        private Purchase(Guid initiator, Guid supplierId)
        {
            UserId = initiator;
            SupplierId = supplierId;
            CreatedOn = DateTimeRangeExtensions.GetDate();
            PurchaseStage = PurchaseStage.New;
            Processes = new List<PurchaseProcess>();
            Items = new List<Item>();
            Documents = new List<Document>();
        }
        public void AddItem(string name, string description, string barCode, decimal quantity, Money pricePerItem)
            => Items.Add(new Item(this.Id, name, description, barCode, quantity, pricePerItem));
        public void AddProcess(PurchaseStage purchaseStage, Guid maker, string comments)
            => Processes.Add(new PurchaseProcess(this.Id, purchaseStage, maker, comments));
        public void AddDocument(string path) => Documents.Add(new Document(this.Id, path));
        public Guid UserId { get; set; }
        public Guid SupplierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public PurchaseStage PurchaseStage { get; set; }
        public List<PurchaseProcess> Processes { get; set; }
        public List<Item> Items { get; set; }
        public List<Document> Documents { get; set; }
        public List<Account> Accounts { get; set; }
        public Supplier Supplier { get; set; }
        public User User { get; set; }
    }
}
