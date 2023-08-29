using System;
using DataAccess;
using System.Windows;
using DataAccess.Models;

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Window
    {
        #region [- ctors -]
        private ProductDataAccess productDataAccess;
        private Product editingProduct;
        private bool isEdit = false;
        #endregion

        #region [- ctors -]
        public AddEditProduct(ProductDataAccess prdDataAccess)
        {
            InitializeComponent();
            productDataAccess = prdDataAccess;
        }

        public AddEditProduct(ProductDataAccess prdDataAccess, Product prd)
        {
            InitializeComponent();
            productDataAccess = prdDataAccess;
            editingProduct = prd;
            isEdit = true;
            tbName.Text = editingProduct.Name;
            tbAuthor.Text = editingProduct.Author;
            tbPrice.Text = editingProduct.Price.ToString();
            tbAvailableCount.Text = editingProduct.AvailableCount.ToString();
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
            isValid = CheckProductValidity();

            if (isValid)
            {
                if (isEdit)
                {
                    Product prd = new Product()
                    {
                        Id = editingProduct.Id,
                        Name = tbName.Text,
                        Author = tbAuthor.Text,
                        Price = Convert.ToDecimal(tbPrice.Text),
                        AvailableCount = (int)Convert.ToUInt64(tbAvailableCount.Text)
                    };
                    productDataAccess.EditProduct(prd);
                }
                else
                {
                    Product prd = new Product()
                    {
                        Id = productDataAccess.GetNextId(),
                        Name = tbName.Text,
                        Author = tbAuthor.Text,
                        Price = Convert.ToDecimal(tbPrice.Text),
                        AvailableCount = (int)Convert.ToUInt64(tbAvailableCount.Text)
                    };
                    productDataAccess.AddProduct(prd);
                }
                this.Close();
            }
        }
        #endregion

        #region [- CheckProductValidity() -]
        private bool CheckProductValidity()
        {
            bool isValid = true;
            string Name = tbName.Text.Trim().ToLower();
            string Author = tbAuthor.Text.Trim().ToLower();
            string Price = tbPrice.Text.Trim().ToLower();
            string AvailableCount = tbAvailableCount.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(Name))
            {
                isValid = false;
                lblError.Content = "**Name is invalid!";
            }
            else if (string.IsNullOrEmpty(Author))
            {
                isValid = false;
                lblError.Content = "**Author is invalid!";
            }
            else if (!decimal.TryParse(Price, out decimal b) || string.IsNullOrEmpty(Price))
            {
                isValid = false;
                lblError.Content = "**Price is invalid!";
            }
            else if (!UInt64.TryParse(AvailableCount, out ulong p) || string.IsNullOrEmpty(AvailableCount))
            {
                isValid = false;
                lblError.Content = "**Available Count is invalid!";
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