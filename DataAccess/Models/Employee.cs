namespace DataAccess.Models
{
    public class Employee : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
        public decimal BaseSalary { get; set; }

        public string GetBasicInfo()
        {
            string dinalStr = FirstName + " " + LastName + 
                "\nAddress: " + Address +
                "\nTell: " + PhoneNumber + 
                "\nDepartment: " + Department + 
                "\nBase Salary: " + BaseSalary;
            return dinalStr;
        }
    }

    public enum Department
    {
        Production,
        Sales,
        Advertisment,
        Mangement
    }
}