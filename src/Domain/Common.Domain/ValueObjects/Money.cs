using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.ValueObjects
{
    public class Money
    {
        //This is a full Value object now
        public static Money Create(string currency, decimal amount, DateTime? time = null)
        {
            DateTime t = time != null ? time.Value : DateTimeRangeExtensions.GetDate();
            return new Money(currency, amount, t);
        }
        private Money() { }
        //Enum Currencies ????????????????????????????????????????????????????????????????
        private Money(string currency, decimal amount, DateTime time)
        {
            if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentNullException(nameof(currency));
            if (amount < 0M) throw new ArgumentOutOfRangeException(nameof(amount));
            Currency = currency.Trim().ToUpper(); Amount = amount; Time = time;
        }
        public string Currency { get; private set; } // Private set or just get operator makes it Immutable ==> Private set Coz of EF
        public decimal Amount { get; private set; } // Make's sure values cannot be changes individually 
        public DateTime Time { get; private set; }
        public override string ToString() => $"{Currency} {Amount.ToString("N2")}";
        public override bool Equals(object obj)
        {
            return obj is Money money &&
                   Currency == money.Currency &&
                   Amount == money.Amount &&
                   Time == money.Time;
        }
        public override int GetHashCode()
        {
            var hashCode = 624119691;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Currency);
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + Time.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(Money left, Money right)
        {
            return EqualityComparer<Money>.Default.Equals(left, right);
        }
        public static bool operator !=(Money left, Money right)
        {
            return !(left == right);
        }
    }
}
