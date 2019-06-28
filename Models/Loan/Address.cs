namespace Models.Loan
{
    public class Address : ILoanObject<AddressFieldList>
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
    }
}
