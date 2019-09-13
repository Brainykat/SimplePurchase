﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.ValueObjects
{
    public class AccountNumber
    {
        private AccountNumber(int cOACODE, long number, string bearerCode)
        {
            if (string.IsNullOrWhiteSpace(bearerCode)) throw new ArgumentNullException(nameof(bearerCode));
            if (cOACODE <= 0) throw new ArgumentOutOfRangeException(nameof(cOACODE));
            if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number));
            COACODE = cOACODE;
            Number = number;
            BearerCode = bearerCode;
        }
        public static AccountNumber Create(int cOACODE, long number, string bearerCode) =>
            new AccountNumber(cOACODE, number, bearerCode);
        private AccountNumber() { }
        public int COACODE { get; private set; }
        public long Number { get; private set; }
        public string BearerCode { get; private set; }
        public override string ToString() => $"{COACODE}{Number.ToString().PadLeft(6, '0')}{BearerCode}";

        public override bool Equals(object obj)
        {
            return obj is AccountNumber number &&
                   COACODE == number.COACODE &&
                   Number == number.Number &&
                   BearerCode == number.BearerCode;
        }

        public override int GetHashCode()
        {
            var hashCode = 1251919988;
            hashCode = hashCode * -1521134295 + COACODE.GetHashCode();
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BearerCode);
            return hashCode;
        }

        public static bool operator ==(AccountNumber left, AccountNumber right)
        {
            return EqualityComparer<AccountNumber>.Default.Equals(left, right);
        }

        public static bool operator !=(AccountNumber left, AccountNumber right)
        {
            return !(left == right);
        }
    }
}
