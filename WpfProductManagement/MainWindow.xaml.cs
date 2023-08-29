using DataAccess;
using System.Windows;
using DataAccess.Models;
using System.Collections.ObjectModel;

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region [- fields -]
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        CustomerDataAccess customerDataAccess = new CustomerDataAccess();
        ProductDataAccess productDataAccess = new ProductDataAccess();

        //ObservableCollection Can Refresh Grid Continously
        ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();
        ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();
        ObservableCollection<Product> Products = new ObservableCollection<Product>();
        #endregion

        #region [- props -]
        public Employee currentEmployee { get; set; } = new Employee();
        public Customer currentCustomer { get; set; } = new Customer();
        public Product currentProduct { get; set; } = new Product(); 
        #endregion

        #region [- MainWindow() -]
        public MainWindow()
        {
            InitializeComponent();
            fillData();
            EmployeesGrid.ItemsSource = Employees;
            CustomersGrid.ItemsSource = Customers;
            ProductsGrid.ItemsSource = Products;
        }
        #endregion

        #region [- fillData() -]
        private void fillData()
        {
            Employees = employeeDataAccess.Employees;
            Customers = customerDataAccess.Customers;
            Products = productDataAccess.Products;
        }
        #endregion

        #region [-  btnHome_Click(object sender, RoutedEventArgs e) -]
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region [- btnEmployees_Click(object sender, RoutedEventArgs e) -]
        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region [- btnCustomers_Click(object sender, RoutedEventArgs e) -]
        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region [- btnProducts_Click(object sender, RoutedEventArgs e) -]
        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Visible;
        }
        #endregion

        #region [- Employee CRUD -]
        #region [-  EmployeesGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) -]
        private void EmployeesGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesGrid.SelectedItem as Employee;
                EmployeeLabel.Content = currentEmployee.GetBasicInfo();
            }
        }
        #endregion

        #region [- btnAddEmployee_Click(object sender, RoutedEventArgs e) -]
        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployee addWindow = new AddEditEmployee(employeeDataAccess);
            addWindow.ShowDialog();
        }
        #endregion

        #region [- btnDeleteEmployee_Click(object sender, RoutedEventArgs e) -]
        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesGrid.SelectedItem as Employee;
                employeeDataAccess.RemoveEmployee(currentEmployee.Id);
                EmployeeLabel.Content = "---";
            }
        }
        #endregion

        #region [- btnEditEmployee_Click(object sender, RoutedEventArgs e) -]
        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesGrid.SelectedItem as Employee;
                AddEditEmployee addWindow = new AddEditEmployee(employeeDataAccess, currentEmployee);
                addWindow.ShowDialog();
            }
        }
        #endregion
        #endregion

        #region -[ Customer CRUD -]
        #region [- CustomersGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) -]
        private void CustomersGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                currentCustomer = CustomersGrid.SelectedItem as Customer;
                CustomerLabel.Content = currentCustomer.GetBasicInfo();
            }
        }
        #endregion

        #region [- btnAddCustomer_Click(object sender, RoutedEventArgs e) -]
        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomer addWindow = new AddEditCustomer(customerDataAccess);
            addWindow.ShowDialog();
        }
        #endregion

        #region [- btnDeleteCustomer_Click(object sender, RoutedEventArgs e) -]
        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            currentCustomer = CustomersGrid.SelectedItem as Customer;
            customerDataAccess.RemoveCustomer(currentCustomer.Id);
            CustomerLabel.Content = "---";
        }
        #endregion

        #region [- btnEditCustomer_Click(object sender, RoutedEventArgs e) -]
        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                currentCustomer = CustomersGrid.SelectedItem as Customer;
                AddEditCustomer addWindow = new AddEditCustomer(customerDataAccess, currentCustomer);
                addWindow.ShowDialog();
            }
        }
        #endregion
        #endregion

        #region [- Product CRUD -]
        #region [- ProductsGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) -]
        private void ProductsGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                currentProduct = ProductsGrid.SelectedItem as Product;
                ProductLabel.Content = currentProduct.GetBasicInfo();
            }
        }
        #endregion

        #region [- btnAddProduct_Click(object sender, RoutedEventArgs e) -]
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProduct addWindow = new AddEditProduct(productDataAccess);
            addWindow.ShowDialog();
        }
        #endregion

        #region [- btnDeleteProduct_Click(object sender, RoutedEventArgs e) -]
        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            currentProduct = ProductsGrid.SelectedItem as Product;
            productDataAccess.RemoveProduct(currentProduct.Id);
            ProductLabel.Content = "---";
        }
        #endregion

        #region [- btnEditProduct_Click(object sender, RoutedEventArgs e) -]
        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                currentProduct = ProductsGrid.SelectedItem as Product;
                AddEditProduct addWindow = new AddEditProduct(productDataAccess, currentProduct);
                addWindow.ShowDialog();
            }
        }
        #endregion 
        #endregion
    }
}