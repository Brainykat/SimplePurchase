using Common.Domain;
using Common.Domain.ValueObjects;
using HR.Domain.Entities;
using HR.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Domain
{
    public class Employee : EntityBase
    {
        private Employee(string jobNumber, Guid jobTypeId, Guid jobTitleId, Guid suffixId, Name name, long phone, string email,
            Guid genderId, Guid maritalStatusId, DateTime dOB, Guid idTypeId, string idNumber,
            Guid nationalityId, Guid countyId, PaymentMode paymentMode, Guid branchId, string accountNumber,
             Money basicSalary, string kraPin, long nHIF, long nSSF, DateTime? hireDate = null,
             string secondaryPhone = null, Guid reportTo = default, bool isSystemUser = false)
        {
            if (string.IsNullOrWhiteSpace(jobNumber)) throw new ArgumentNullException(nameof(jobNumber));
            if (jobTypeId == Guid.Empty) throw new ArgumentNullException(nameof(jobTypeId));
            if (jobTitleId == Guid.Empty) throw new ArgumentNullException(nameof(jobTitleId));
            if (suffixId == Guid.Empty) throw new ArgumentNullException(nameof(suffixId));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (phone.ToString().Length < 7) throw new ArgumentOutOfRangeException(nameof(phone));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
            if (genderId == Guid.Empty) throw new ArgumentNullException(nameof(genderId));
            if (maritalStatusId == Guid.Empty) throw new ArgumentNullException(nameof(maritalStatusId));
            DOB = dOB;
            if (Age() < 18) throw new ArgumentOutOfRangeException(nameof(dOB), "Cannot be a Minor; Legally");
            if (idTypeId == Guid.Empty) throw new ArgumentNullException(nameof(idTypeId));
            if (string.IsNullOrWhiteSpace(idNumber)) throw new ArgumentNullException(nameof(idNumber));
            if (nationalityId == Guid.Empty) throw new ArgumentNullException(nameof(nationalityId));
            if (countyId == Guid.Empty) throw new ArgumentNullException(nameof(countyId));
            if (branchId == Guid.Empty) throw new ArgumentNullException(nameof(branchId));
            if (string.IsNullOrWhiteSpace(accountNumber)) throw new ArgumentNullException(nameof(accountNumber));
            GenerateNewIdentity();
            JobNumber = jobNumber;
            JobTypeId = jobTypeId;
            JobTitleId = jobTitleId;
            SuffixId = suffixId;
            Phone = phone;
            Email = email;
            GenderId = genderId;
            MaritalStatusId = maritalStatusId;
            IdTypeId = idTypeId;
            IdNumber = idNumber;
            NationalityId = nationalityId;
            CountyId = countyId;
            SecondaryPhone = secondaryPhone;
            PaymentMode = paymentMode;
            BranchId = branchId;
            AccountNumber = accountNumber;
            BasicSalary = basicSalary ?? throw new ArgumentNullException(nameof(basicSalary));
            HireDate = hireDate == null ? DateTimeRangeExtensions.GetDate() : hireDate.Value;
            KraPin = kraPin ?? throw new ArgumentNullException(nameof(kraPin));
            NHIF = nHIF;
            NSSF = nSSF;
            ReportTo = reportTo;
            IsSystemUser = isSystemUser;
        }
        public static Employee Create(string jobNumber, Guid jobTypeId, Guid jobTitleId, Guid suffixId, Name name, long phone, string email,
            Guid genderId, Guid maritalStatusId, DateTime dOB, Guid idTypeId, string idNumber,
            Guid nationalityId, Guid countyId, PaymentMode paymentMode, Guid branchId, string accountNumber,
             Money basicSalary, string kraPin, long nHIF, long nSSF, DateTime? hireDate = null,
             string secondaryPhone = null, Guid reportTo = default, bool isSystemUser = false) =>
            new Employee(jobNumber, jobTypeId, jobTitleId, suffixId, name, phone, email, genderId, maritalStatusId, dOB,
                idTypeId, idNumber, nationalityId, countyId, paymentMode, branchId, accountNumber, basicSalary, kraPin,
                nHIF, nSSF, hireDate, secondaryPhone, reportTo, isSystemUser);

        private Employee() { }
        public Guid JobTypeId { get; set; }
        public Guid JobTitleId { get; set; }
        public Guid SuffixId { get; set; }
        public string JobNumber { get; set; }
        public Name Name { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public Guid GenderId { get; set; }
        public Guid MaritalStatusId { get; set; }
        public DateTime DOB { get; set; }
        public Guid IdTypeId { get; set; }
        public string IdNumber { get; set; }
        public Guid NationalityId { get; set; }
        public Guid CountyId { get; set; }
        public string SecondaryPhone { get; set; }
        public PaymentMode PaymentMode { get; set; }
        public Guid BranchId { get; set; }
        public string AccountNumber { get; set; }
        public Money BasicSalary { get; set; }
        public DateTime HireDate { get; set; }
        public string KraPin { get; set; }
        public long NHIF { get; set; }
        public long NSSF { get; set; }
        public Guid ReportTo { get; set; }
        public bool IsSystemUser { get; set; }
        public Suffix Suffix { get; set; }
        public JobType JobType { get; set; }
        public JobTitle JobTitle { get; set; }
        public int Age()=> DateTimeRangeExtensions.GetDate().Year - DOB.Year;
        

    }
}
