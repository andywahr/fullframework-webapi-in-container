using System;
using Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MappingTests
    {
        [TestMethod]
        public void FromLoanToLoanObject()
        {

            Loan originalLoan = new Loan()
            {
                LoanAmount = 250000.01,
                PrimaryBorrower = new Person()
                {
                    FirstName = "Joe",
                    LastName = "Smith",
                    DateOfBirth = DateTime.Parse("1/1/2000"),
                    HomeAddress = new Address()
                    {
                        Street = "101 Main Street",
                        City = "Dallas",
                        State = "Texas",
                        Zip = 75001
                    }
                }
            };

            LoanObject newLoanObject = new LoanObject();

            originalLoan.MapTo(newLoanObject);

            Assert.AreEqual("250000.01", newLoanObject.Properties[FieldList.LoanAmount].Value);
            Assert.AreEqual("Joe", newLoanObject.Properties[FieldList.PrimaryBorrower.FirstName].Value);
            Assert.AreEqual("Smith", newLoanObject.Properties[FieldList.PrimaryBorrower.LastName].Value);
            Assert.AreEqual("1/1/2000 12:00:00 AM", newLoanObject.Properties[FieldList.PrimaryBorrower.DateOfBirth].Value);
            Assert.AreEqual("101 Main Street", newLoanObject.Properties[FieldList.PrimaryBorrower.HomeAddress.Street].Value);
            Assert.AreEqual("Dallas", newLoanObject.Properties[FieldList.PrimaryBorrower.HomeAddress.City].Value);
            Assert.AreEqual("Texas", newLoanObject.Properties[FieldList.PrimaryBorrower.HomeAddress.State].Value);
            Assert.AreEqual("75001", newLoanObject.Properties[FieldList.PrimaryBorrower.HomeAddress.Zip].Value);
        }

        [TestMethod]
        public void FromLoanObjectToLoan()
        {

            LoanObject originalLoan = new LoanObject();

            originalLoan.SetValue(FieldList.LoanAmount, "250000.01");
            originalLoan.SetValue(FieldList.PrimaryBorrower.FirstName, "Joe");
            originalLoan.SetValue(FieldList.PrimaryBorrower.LastName, "Smith");
            originalLoan.SetValue(FieldList.PrimaryBorrower.DateOfBirth, "1/1/2000 12:00:00 AM");
            originalLoan.SetValue(FieldList.PrimaryBorrower.HomeAddress.Street, "101 Main Street");
            originalLoan.SetValue(FieldList.PrimaryBorrower.HomeAddress.City, "Dallas");
            originalLoan.SetValue(FieldList.PrimaryBorrower.HomeAddress.State, "Texas");
            originalLoan.SetValue(FieldList.PrimaryBorrower.HomeAddress.Zip, "75001");

            Loan newLoanObject = Loan.MapFrom(originalLoan);

            Assert.AreEqual(250000.01, newLoanObject.LoanAmount);
            Assert.AreEqual("Joe", newLoanObject.PrimaryBorrower.FirstName);
            Assert.AreEqual("Smith", newLoanObject.PrimaryBorrower.LastName);
            Assert.AreEqual(DateTime.Parse("1/1/2000"), newLoanObject.PrimaryBorrower.DateOfBirth);
            Assert.AreEqual("101 Main Street", newLoanObject.PrimaryBorrower.HomeAddress.Street);
            Assert.AreEqual("Dallas", newLoanObject.PrimaryBorrower.HomeAddress.City);
            Assert.AreEqual("Texas", newLoanObject.PrimaryBorrower.HomeAddress.State);
            Assert.AreEqual(75001, newLoanObject.PrimaryBorrower.HomeAddress.Zip);
        }
    }
}
