
using Employee.Shared.Entities;

namespace Employee.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckEmployee();
        }

        private async Task CheckEmployee()
        {
            if (!_context.employees.Any())
            {
                _context.employees.Add(new EmployeeModel
                {
                    FirstName = "Daniel",
                    LastName = "Gómez",
                    HireDate = DateTime.Now,
                    IsActive = true,
                    Salary = 1800000
                });
                _context.employees.Add(new EmployeeModel
                {
                    FirstName = "Anthony",
                    LastName = "Gómez",
                    HireDate = DateTime.Now,
                    IsActive = true,
                    Salary = 1300000
                });
                _context.employees.Add(new EmployeeModel
                {
                    FirstName = "Leydi",
                    LastName = "Montoya",
                    HireDate = DateTime.Now,
                    IsActive = true,
                    Salary = 1500000
                });
                _context.employees.Add(new EmployeeModel
                {
                    FirstName = "Manuela",
                    LastName = "Ruiz",
                    HireDate = DateTime.Now,
                    IsActive = true,
                    Salary = 2000000
                });
                _context.employees.Add(new EmployeeModel
                {
                    FirstName = "Oscar",
                    LastName = "Cardona",
                    HireDate = DateTime.Now,
                    IsActive = true,
                    Salary = 1600000
                });
                _context.employees.Add(new EmployeeModel
                {
                    FirstName = "Valentina",
                    LastName = "Escobar",
                    HireDate = DateTime.Now,
                    IsActive = true,
                    Salary = 1700000
                });
                _context.employees.Add(new EmployeeModel
                {
                    FirstName = "Johanna",
                    LastName = "Galvis",
                    HireDate = DateTime.Now,
                    IsActive = true,
                    Salary = 1900000
                });
                _context.employees.Add(new EmployeeModel
                {
                    FirstName = "Daniela",
                    LastName = "Lopera",
                    HireDate = DateTime.Now,
                    IsActive = true,
                    Salary = 2100000
                });
                _context.employees.Add(new EmployeeModel
                {
                    FirstName = "Ana",
                    LastName = "Torres",
                    HireDate = DateTime.Now,
                    IsActive = true,
                    Salary = 2200000
                });
                _context.employees.Add(new EmployeeModel
                {
                    FirstName = "Yuliana",
                    LastName = "Cardona",
                    HireDate = DateTime.Now,
                    IsActive = true,
                    Salary = 1900000
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}
