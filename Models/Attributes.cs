using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LoanObjectPropertyAttribute : Attribute
    {
        public LoanObjectPropertyAttribute(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }

    public class LoanChildObjectAttribute : Attribute
    {
    }

    public interface ILoanObject
    {

    }

    public interface ILoanObject<T> 
    {

    }

}
