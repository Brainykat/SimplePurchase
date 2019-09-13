using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.Domain.Entities
{
    public class Document
    {
        private Document() { }
        public Document(Guid purchaseId, int id, string path)
        {
            PurchaseId = purchaseId;
            Id = id;
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }
        public Guid PurchaseId { get; set; }
        public int Id { get; set; }
        public string Path { get; set; }
    }
}
