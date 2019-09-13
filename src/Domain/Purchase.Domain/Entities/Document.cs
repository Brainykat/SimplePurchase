using System;

namespace Purchase.Domain.Entities
{
    public class Document
    {
        private Document() { }
        internal Document(Guid purchaseId,string path)
        {
            PurchaseId = purchaseId;
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }
        public Guid PurchaseId { get; set; }
        public int Id { get; set; }
        public string Path { get; set; }
    }
}
