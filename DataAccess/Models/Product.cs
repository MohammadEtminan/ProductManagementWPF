namespace DataAccess.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }

        public string GetBasicInfo()
        {
            string finalStr = 
                "Book Name: " + Name + 
                "\nAuthor: " + Author + 
                "\nPrice: " + Price + 
                "$ \nAvailable Count: " + AvailableCount;
            return finalStr;
        }
    }
}