namespace Models.Loan
{

    public partial class Loan : ILoanObject
    {
        [LoanChildObject]
        public Person PrimaryBorrower { get; set; }

        [LoanChildObject]
        public Person SecondaryBorrower { get; set; }

        [LoanObjectProperty(FieldList.LoanAmount)]
        public double LoanAmount { get; set; }

        [LoanChildObject]
        public Address PropertyLocation { get; set; }
    }

}
