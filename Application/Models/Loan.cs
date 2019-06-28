using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{

    public class Loan
    {
        public Person PrimaryBorrower { get; set; }
        public Person SecondaryBorrower { get; set; }
        public double LoanAmount { get; set; }
        public Address PropertyLocation { get; set; }

        public void MapTo(LoanObject loanObject)
        {
            loanObject.MapValue(FieldList.LoanAmount, LoanAmount);
            PropertyLocation?.MapTo(loanObject, FieldList.PropertyAddress);
            PrimaryBorrower?.MapTo(loanObject, FieldList.PrimaryBorrower);
            SecondaryBorrower?.MapTo(loanObject, FieldList.SecondaryBorrower);
        }

        public static Loan MapFrom(LoanObject loanObject, Loan original = null)
        {
            var address = Address.MapFrom(loanObject, FieldList.PropertyAddress, original?.PropertyLocation);
            var primaryBorrower = Person.MapFrom(loanObject, FieldList.PrimaryBorrower, original?.PrimaryBorrower);
            var secondaryBorrower = Person.MapFrom(loanObject, FieldList.SecondaryBorrower, original?.SecondaryBorrower);

            if (loanObject.ContainsValues(FieldList.LoanAmount) || address != null || primaryBorrower != null || secondaryBorrower != null)
            {
                if (original == null)
                {
                    original = new Loan();
                }

                original.PropertyLocation = address;
                original.PrimaryBorrower = primaryBorrower;
                original.SecondaryBorrower = secondaryBorrower;

                MappingUtil.SetValue(loanObject, FieldList.LoanAmount, (val) => original.LoanAmount = val, original.LoanAmount);
            }

            return original;
        }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }

        public void MapTo(LoanObject loanObject, AddressFieldList addressFields)
        {
            loanObject.MapValue(addressFields.Street, Street);
            loanObject.MapValue(addressFields.City, City);
            loanObject.MapValue(addressFields.Zip, Zip, 0);
            loanObject.MapValue(addressFields.State, State);
        }

        public static Address MapFrom(LoanObject loanObject, AddressFieldList addressFields, Address original = null)
        {
            if (loanObject.ContainsValues(addressFields.State, addressFields.City, addressFields.Zip, addressFields.State))
            {
                if (original == null)
                {
                    original = new Address();
                }

                MappingUtil.SetValue(loanObject, addressFields.Street, (val) => original.Street = val, original.Street);
                MappingUtil.SetValue(loanObject, addressFields.City, (val) => original.City = val, original.City);
                MappingUtil.SetValue(loanObject, addressFields.Zip, (val) => original.Zip = val, original.Zip);
                MappingUtil.SetValue(loanObject, addressFields.State, (val) => original.State = val, original.State);
            }

            return original;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address HomeAddress { get; set; }

        public void MapTo(LoanObject loanObject, PersonFieldList personFields)
        {
            loanObject.MapValue(personFields.FirstName, FirstName);
            loanObject.MapValue(personFields.LastName, LastName);
            loanObject.MapValue(personFields.DateOfBirth, DateOfBirth);
            HomeAddress?.MapTo(loanObject, personFields.HomeAddress);
        }

        public static Person MapFrom(LoanObject loanObject, PersonFieldList personFields, Person original = null)
        {
            var address = Address.MapFrom(loanObject, personFields.HomeAddress, original?.HomeAddress);

            if (loanObject.ContainsValues(personFields.FirstName, personFields.LastName, personFields.DateOfBirth) || address != null)
            {
                if (original == null)
                {
                    original = new Person();
                }

                original.HomeAddress = address;

                MappingUtil.SetValue(loanObject, personFields.FirstName, (val) => original.FirstName = val, original.FirstName);
                MappingUtil.SetValue(loanObject, personFields.LastName, (val) => original.LastName = val, original.LastName);
                MappingUtil.SetValue(loanObject, personFields.DateOfBirth, (val) => original.DateOfBirth = val, original.DateOfBirth);
            }

            return original;
        }
    }
}
