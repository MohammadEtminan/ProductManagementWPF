using System.Linq;
using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public class CustomerDataAccess
    {
        #region [- props -]
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();
        #endregion

        #region [- ctor -]
        public CustomerDataAccess()
        {
            ReadCustomers();
        }
        #endregion

        #region [- ReadCustomers -]
        private void ReadCustomers()
        {
            Customer cust1 = new Customer()
            {
                Id = 1,
                FirstName = "Samuel",
                LastName = "L Jackson",
                PhoneNumber = 9123214569,
                Address = "Hollywood",
            };

            Customer cust2 = new Customer()
            {
                Id = 2,
                FirstName = "Michael",
                LastName = "Jordan",
                PhoneNumber = 9121214369,
                Address = "Chicago",
            };

            Customers.Add(cust1);
            Customers.Add(cust2);
        }
        #endregion

        #region [- AddCustomer(Customer customer) -]
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
        #endregion

        #region [- public void RemoveCustomer(int id) -]
        public void RemoveCustomer(int id)
        {
            Customer temp = Customers.First(x => x.Id == id);
            Customers.Remove(temp);
        }
        #endregion

        #region [- EditCustomer(Customer customer) -]
        public void EditCustomer(Customer customer)
        {
            Customer temp = Customers.First(x => x.Id == customer.Id);
            int index = Customers.IndexOf(temp);
            Customers[index] = customer;
        }
        #endregion

        #region [- GetNextId() -]
        public int GetNextId()
        {
            int index = Customers.Any() ? Customers.Max(x => x.Id) + 1 : 1;
            return index;
        } 
        #endregion
    }
}