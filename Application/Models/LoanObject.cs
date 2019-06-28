using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class LoanObject
    {
        public Dictionary<int, LoanProperty> Properties { get; set; }

        public bool ContainsValues(params int[] ids)
        {
            foreach ( var id in ids )
            {
                if ( Properties.ContainsKey(id))
                {
                    return true;
                }
            }

            return false;
        }

        public void MapValue<T>(int id, T value, T emptyValue = default) where T : IComparable<T>
        {
            if (value.CompareTo(emptyValue) == 0)
            {
                RemoveValue(id);
            }
            else
            {
                SetValue(id, value.ToString());
            }
        }

        public void MapValue(int id, string value)
        {
            if ( string.IsNullOrEmpty(value))
            {
                RemoveValue(id);
            }
            else
            {
                SetValue(id, value.ToString());
            }
        }

        public void SetValue(int id, string value)
        {
            if ( Properties == null )
            {
                Properties = new Dictionary<int, LoanProperty>();
            }

            Properties[id] = new LoanProperty() { Id = id, Value = value };
        }

        public void RemoveValue(int id)
        {
            if (Properties?.ContainsKey(id) ?? false)
            {
                Properties.Remove(id);
            }
        }
    }

    public class LoanProperty
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
