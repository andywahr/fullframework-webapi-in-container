using Models;
using Models.Loan;

namespace Mapper
{

    public static class AddressExtension
    {
        public static void MapTo(this Models.Loan.Address address, Application.Models.LoanObject loanObject, AddressFieldList fields)
        {
            loanObject.MapValue(fields.Street, address.Street);
            loanObject.MapValue(fields.City, address.City);
            loanObject.MapValue(fields.Zip, address.Zip);
            loanObject.MapValue(fields.State, address.State);
        }

        public static Models.Loan.Address MapFrom(Application.Models.LoanObject loanObject, AddressFieldList fields, Models.Loan.Address address = null)
        {
			bool changed = false;

			changed = changed || loanObject.ContainsValues(fields.Street,fields.City,fields.Zip,fields.State);
			

			if (changed)
            {
                if (address == null)
                {
                    address = new Address();
                }

				MappingUtil.SetValue(loanObject, fields.Street, (val) => address.Street = val, address.Street);
				MappingUtil.SetValue(loanObject, fields.City, (val) => address.City = val, address.City);
				MappingUtil.SetValue(loanObject, fields.Zip, (val) => address.Zip = val, address.Zip);
				MappingUtil.SetValue(loanObject, fields.State, (val) => address.State = val, address.State);
            }

            return address;
        }

	}


    public static class LoanExtension
    {
        public static void MapTo(this Models.Loan.Loan loan, Application.Models.LoanObject loanObject)
        {
            loanObject.MapValue(15, loan.LoanAmount);
            loan.PrimaryBorrower?.MapTo(loanObject, FieldList.PrimaryBorrower);
            loan.SecondaryBorrower?.MapTo(loanObject, FieldList.SecondaryBorrower);
            loan.PropertyLocation?.MapTo(loanObject, FieldList.PropertyLocation);
        }

        public static Models.Loan.Loan MapFrom(Application.Models.LoanObject loanObject, Models.Loan.Loan loan = null)
        {
			bool changed = false;

			var _primaryborrower = PersonExtension.MapFrom(loanObject, FieldList.PrimaryBorrower, loan?.PrimaryBorrower);
			changed = changed || (_primaryborrower != null);

			var _secondaryborrower = PersonExtension.MapFrom(loanObject, FieldList.SecondaryBorrower, loan?.SecondaryBorrower);
			changed = changed || (_secondaryborrower != null);

			var _propertylocation = AddressExtension.MapFrom(loanObject, FieldList.PropertyLocation, loan?.PropertyLocation);
			changed = changed || (_propertylocation != null);

            changed = changed || loanObject.ContainsValues(FieldList.LoanAmount);

			if (changed)
            {
                if (loan == null)
                {
                    loan = new Loan();
                }

				loan.PrimaryBorrower = _primaryborrower;
				loan.SecondaryBorrower = _secondaryborrower;
				loan.PropertyLocation = _propertylocation;
				MappingUtil.SetValue(loanObject, FieldList.LoanAmount, (val) => loan.LoanAmount = val, loan.LoanAmount);
            }

            return loan;
        }
	}


    public static class PersonExtension
    {
        public static void MapTo(this Models.Loan.Person person, Application.Models.LoanObject loanObject, PersonFieldList fields)
        {
            loanObject.MapValue(fields.FirstName, person.FirstName);
            loanObject.MapValue(fields.LastName, person.LastName);
            loanObject.MapValue(fields.DateOfBirth, person.DateOfBirth);
            person.HomeAddress?.MapTo(loanObject, fields.HomeAddress);
        }

        public static Models.Loan.Person MapFrom(Application.Models.LoanObject loanObject, PersonFieldList fields, Models.Loan.Person person = null)
        {
			bool changed = false;


			var _homeaddress = AddressExtension.MapFrom(loanObject, fields.HomeAddress, person?.HomeAddress);
			changed = changed || _homeaddress  != null;
			changed = changed || loanObject.ContainsValues(fields.FirstName,fields.LastName,fields.DateOfBirth);
			

			if (changed)
            {
                if (person == null)
                {
                    person = new Person();
                }

				person.HomeAddress = _homeaddress;
				MappingUtil.SetValue(loanObject, fields.FirstName, (val) => person.FirstName = val, person.FirstName);
				MappingUtil.SetValue(loanObject, fields.LastName, (val) => person.LastName = val, person.LastName);
				MappingUtil.SetValue(loanObject, fields.DateOfBirth, (val) => person.DateOfBirth = val, person.DateOfBirth);
            }

            return person;
        }

	}

}
