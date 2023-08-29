namespace DataAccess.Models
{
    public class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Address { get; set; }

        public string GetBasicInfo()
        {
            string finalStr = FirstName + " " + LastName +
                "\nTell: " + PhoneNumber + 
                "\nAddress: " + Address;
            return finalStr;
        }
    }
}