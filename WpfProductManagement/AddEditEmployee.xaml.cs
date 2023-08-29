using System;
using DataAccess;
using System.Windows;
using DataAccess.Models;

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        #region [- fields -]
        private EmployeeDataAccess employeeDataAccess;
        private Employee editingEmployee;
        private bool isEdit = false;
        #endregion

        #region [- ctors -]
        public AddEditEmployee(EmployeeDataAccess empDataAccess)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
        } 

        public AddEditEmployee(EmployeeDataAccess empDataAccess, Employee emp)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
            editingEmployee = emp;
            isEdit = true;
            tbFirstName.Text = editingEmployee.FirstName;
            tbLastName.Text = editingEmployee.LastName;
            tbPhoneNumber.Text = editingEmployee.PhoneNumber.ToString();
            tbAddress.Text = editingEmployee.Address;
            tbSalary.Text = editingEmployee.BaseSalary.ToString();
            comboDepartment.SelectedIndex = (int)editingEmployee.Department;
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
            isValid = CkeckEmployeeValidity();

            if (isValid)
            {
                if (isEdit)
                {

                    Employee emp = new Employee()
                    {
                        Id = editingEmployee.Id,
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                        Department = (Department)comboDepartment.SelectedIndex,
                        BaseSalary = Convert.ToDecimal(tbSalary.Text)
                    };
                    employeeDataAccess.EditEmployee(emp);
                }
                else
                {
                    Employee emp = new Employee()
                    {
                        Id = employeeDataAccess.GetNextId(),
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                        Department = (Department)comboDepartment.SelectedIndex,
                        BaseSalary = Convert.ToDecimal(tbSalary.Text)
                    };
                    employeeDataAccess.AddEmployee(emp);
                }
                this.Close();
            }

        }
        #endregion

        #region [- CkeckEmployeeValidity() -]
        private bool CkeckEmployeeValidity()
        {
            bool isValid = true;
            string FirstName = tbFirstName.Text.Trim().ToLower();
            string LastName = tbLastName.Text.Trim().ToLower();
            string PhoneNumber = tbPhoneNumber.Text.Trim().ToLower();
            string Address = tbAddress.Text.Trim().ToLower();
            int Department = comboDepartment.SelectedIndex;
            string BaseSalary = tbSalary.Text.Trim().ToLower();

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
            else if (Department < 0)
            {
                isValid = false;
                lblError.Content = "**Please Select a Department!";
            }
            else if (!decimal.TryParse(BaseSalary, out decimal b) || b > 4000)
            {
                isValid = false;
                lblError.Content = "**Salary is invalid!";
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