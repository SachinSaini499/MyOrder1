using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Model
{
  public class CustomerDetail
    {
        private int _customerId;
        private string _customerEmailId;
        private string _customerName;
        private string _customerAddress;
        private string _customerType;
        private string _password;
        public int CustomerId
        {
            get
            {
                var customerId = _customerId;
                return customerId;
            }
            set { _customerId = value; }
        }
        public string CustomerEmailId
        {
            get
            {
                string customerEmailId = _customerEmailId;
                return customerEmailId;
            }
            set { _customerEmailId = value; }
        }
        public string CustomerName
        {
            get
            {
                string customerName = _customerName;
                return customerName;
            }
            set { _customerName = value; }
        }
        public string CustomerAddress
        {
            get
            {
                string customerAddress = _customerAddress;
                return customerAddress;
            }
            set { _customerAddress = value; }
        }
        public string CustomerType
        {
            get
            {
                string customerType = _customerType;
                return customerType;
            }
            set { _customerType = value; }
        }
        public string Password
        {
            get
            {
                string password = _password;
                return password;
            }
            set { _password = value; }
        }

    }
}
