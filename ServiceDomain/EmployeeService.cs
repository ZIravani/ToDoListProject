using ToDoListProject.Models;

namespace ToDoListProject.ServiceDomain
{

    public class EmployeeService : IEmployeeService
    {
        private List<Employee> _employees = new List<Employee>
    {
        new Employee(10895, "Jean Martin", new DateOnly(1985, 3, 16)),
        new Employee(10944, "António Langa", new DateOnly(1991, 12, 1)),
        new Employee(11203, "Julie Smith", new DateOnly(1958, 10, 10)),
        new Employee(11205, "Nur Sari", new DateOnly(1922, 4, 27)),
        new Employee(11898, "Jose Hernandez", new DateOnly(2011, 5, 3)),
        new Employee(12130, "Kenji Sato", new DateOnly(2004, 1, 9)),
        new Employee(12131, "Maria Garcia", new DateOnly(1995, 7, 22)),
        new Employee(12132, "Ahmed Khan", new DateOnly(1988, 11, 15)),
        new Employee(12133, "Li Wei", new DateOnly(1976, 9, 30)),
        new Employee(12134, "Anna Müller", new DateOnly(2000, 2, 14)),
        new Employee(12135, "John Doe", new DateOnly(1999, 8, 5)),
        new Employee(12136, "Jane Doe", new DateOnly(2001, 6, 19)),
        new Employee(12137, "Carlos Ruiz", new DateOnly(1980, 4, 12)),
        new Employee(12138, "Yuki Tanaka", new DateOnly(1992, 3, 8)),
        new Employee(12139, "Olga Ivanova", new DateOnly(1970, 12, 25))
    };

        public Task<List<Employee>> GetEmployeesAsync()
        {
            return Task.FromResult(_employees);
        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.id == id);
            return Task.FromResult(employee);
        }

        public Task AddEmployeeAsync(Employee employee)
        {
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.id == employee.id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.BirthDate = employee.BirthDate;
            }
            return Task.CompletedTask;
        }

        public Task DeleteEmployeeAsync(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return Task.CompletedTask;
        }
    }
}
