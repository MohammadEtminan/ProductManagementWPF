using System.Linq;
using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public class EmployeeDataAccess
    {
        #region [- props -]
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        #endregion

        #region [- ctor -]
        public EmployeeDataAccess()
        {
            ReadEmployees();
        }
        #endregion

        #region [- ReadEmployees() -]
        private void ReadEmployees()
        {
            Employee emp1 = new Employee()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Nash",
                PhoneNumber = 09121111111,
                Address = "WD",
                Department = Department.Production,
                BaseSalary = 2500
            };

            Employee emp2 = new Employee()
            {
                Id = 2,
                FirstName = "Kurt",
                LastName = "Cubain",
                PhoneNumber = 09121111112,
                Address = "NY",
                Department = Department.Mangement,
                BaseSalary = 25000
            };

            Employees.Add(emp1);
            Employees.Add(emp2);
        }
        #endregion

        #region [- AddEmployee(Employee employee)-]
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }
        #endregion

        #region [- RemoveEmployee(int id) -]
        public void RemoveEmployee(int id)
        {
            Employee temp = Employees.First(x => x.Id == id);
            Employees.Remove(temp);
        }
        #endregion

        #region [- EditEmployee(Employee employee) -]
        public void EditEmployee(Employee employee)
        {
            Employee temp = Employees.First(x => x.Id == employee.Id);
            int index = Employees.IndexOf(temp);
            Employees[index] = employee;
        }
        #endregion

        #region [- GetNextId() -]
        public int GetNextId()
        {
            int index = Employees.Any() ? Employees.Max(x => x.Id) + 1 : 1;
            return index;
        } 
        #endregion
    }
}