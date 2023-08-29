using System;
using DataAccess;
using System.Windows;
using DataAccess.Models;

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for AddEditCustomer.xaml
    /// </summary>
    public partial class AddEditCustomer : Window
    {
        #region [- fields -]
        private CustomerDataAccess customerDataAccess;
        private Customer editingCustomer;
        private bool isEdit = false;
        #endregion

        #region [- ctors -]
        public AddEditCustomer(CustomerDataAccess custDataAccess)
        {
            InitializeComponent();
            customerDataAccess = custDataAccess;
        }

        public AddEditCustomer(CustomerDataAccess custDataAccess, Customer cust)
        {
            InitializeComponent();
            customerDataAccess = custDataAccess;
            editingCustomer = cust;
            isEdit = true;
            tbFirstName.Text = editingCustomer.FirstName;
            tbLastName.Text = editingCustomer.LastName;
            tbPhoneNumber.Text = editingCustomer.PhoneNumber.ToString();
            tbAddress.Text = editingCustomer.Address;
        }
        #endregion

        #region [- btnCancel_Click(object sender, RoutedEventArgs e) -]
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region [- btnOK_Click(object sender, RoutedEventArgs e) -]
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            isValid = CkeckCustomerValidity();

            if (isValid)
            {
                if (isEdit)
                {
                    Customer cust = new Customer()
                    {
                        Id = editingCustomer.Id,
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                    };
                    customerDataAccess.EditCustomer(cust);
                }
                else
                {
                    Customer cust = new Customer()
                    {
                        Id = customerDataAccess.GetNextId(),
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                    };
                    customerDataAccess.AddCustomer(cust);
                }
                this.Close();
            }
        }
        #endregion

        #region [- CkeckCustomerValidity() -]
        private bool CkeckCustomerValidity()
        {
            bool isValid = true;
            string FirstName = tbFirstName.Text.Trim().ToLower();
            string LastName = tbLastName.Text.Trim().ToLower();
            string PhoneNumber = tbPhoneNumber.Text.Trim().ToLower();
            string Address = tbAddress.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(FirstName))
            {
                isValid = false;
                lblError.Content = "**First Name is invalid!";
            }
            else if (string.IsNullOrEmpty(LastName))
            {
                isValid = false;
                lblError.Content = "**Last Name is invalid!";
            }
            else if (!UInt64.TryParse(PhoneNumber, out ulong p))
            {
                isValid = false;
                lblError.Content = "**Phone Number is invalid!";
            }
            else if (Address.Contains("paris"))
            {
                isValid = false;
                lblError.Content = "**Paris is not accepted!";
            }
            else
            {
                lblError.Content = "";
            }
            return isValid;
        } 
        #endregion
    }
}