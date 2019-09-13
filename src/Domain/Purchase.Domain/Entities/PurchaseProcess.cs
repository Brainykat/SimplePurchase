using Common.Domain;
using Purchase.Domain.Enums;
using System;

namespace Purchase.Domain.Entities
{
    public class PurchaseProcess : EntityBase
    {
        private PurchaseProcess() { }
        internal PurchaseProcess(Guid purchaseId, PurchaseStage purchaseStage, Guid maker, string comments)
        {
            PurchaseId = purchaseId;
            PurchaseStage = purchaseStage;
            Maker = maker;
            DateTime = DateTimeRangeExtensions.GetDate();
            Comments = comments ?? throw new ArgumentNullException(nameof(comments));
        }

        public Guid PurchaseId { get; set; }
        public PurchaseStage PurchaseStage { get; set; }
        public Guid Maker { get; set; }
        public DateTime DateTime { get; set; }
        public string Comments { get; set; }
    }
}
