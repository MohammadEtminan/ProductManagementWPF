using System.Linq;
using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public class ProductDataAccess
    {
        #region [- props -]
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        #endregion

        #region [- ctor -]
        public ProductDataAccess()
        {
            ReadProducts();
        }
        #endregion

        #region [- ReadProducts() -]
        private void ReadProducts()
        {
            Product pr1 = new Product()
            {
                Id = 1,
                Name = "Animal Farm",
                Author = "George Orwell",
                AvailableCount = 12,
                Price = 17,
            };

            Product pr2 = new Product()
            {
                Id = 2,
                Name = "Brave New World",
                Author = "Aldous Huxley",
                AvailableCount = 5,
                Price = 34
            };

            Products.Add(pr1);
            Products.Add(pr2);
        }
        #endregion

        #region [- AddProduct(Product product) -]
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        #endregion

        #region [- RemoveProduct(int id) -]
        public void RemoveProduct(int id)
        {
            Product temp = Products.First(p => p.Id == id);
            Products.Remove(temp);
        }
        #endregion

        #region [- EditProduct(Product product) -]
        public void EditProduct(Product product)
        {
            Product temp = Products.First(x => x.Id == product.Id);
            int index = Products.IndexOf(temp);
            Products[index] = product;
        }
        #endregion

        #region [- GetNextId() -]
        public int GetNextId()
        {
            int index = Products.Any() ? Products.Max(x => x.Id) + 1 : 1;
            return index;
        } 
        #endregion
    }
}