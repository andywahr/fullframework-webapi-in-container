using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public static class FieldList
    {
        public static readonly PersonFieldList PrimaryBorrower = new PersonFieldList()
        {
            FirstName = 1,
            LastName = 2,
            DateOfBirth = 3,
            HomeAddress = new AddressFieldList()
            {
                Street = 4,
                City = 5,
                Zip = 6,
                State = 7
            }

        };

        public static readonly PersonFieldList SecondaryBorrower = new PersonFieldList()
        {
            FirstName = 8,
            LastName = 9,
            DateOfBirth = 10,
            HomeAddress = new AddressFieldList()
            {
                Street = 11,
                City = 12,
                Zip = 13,
                State = 14
            }

        };

        public const int LoanAmount = 15;

        public static readonly AddressFieldList PropertyAddress = new AddressFieldList()
        {
            Street = 16,
            City = 17,
            Zip = 18,
            State = 19
        };
    }

    public class PersonFieldList
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int DateOfBirth { get; set; }
        public AddressFieldList HomeAddress { get; set; }
    }

    public class AddressFieldList
    {
        public int Street { get; set; }
        public int City { get; set; }
        public int Zip { get; set; }
        public int State { get; set; }
    }
}
