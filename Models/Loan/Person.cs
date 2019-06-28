using System;

namespace Models.Loan
{
    public partial class Person : ILoanObject<PersonFieldList>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address HomeAddress { get; set; }
    }
}
