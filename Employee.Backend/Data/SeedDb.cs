using Employee.Shared.Entities;
using Microsoft.EntityFrameworkCore;

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
            await CheckCountriesFullAsync();
            await CheckData();
            await CheckCountriesAsync();
            await CheckEmployee();
        }

        private async Task CheckCountriesFullAsync()
        {
            if (!_context.countries.Any())
            {
                var countriesSqlScript = File.ReadAllText("Data\\CountriesStatesCities.sql");
                await _context.Database.ExecuteSqlRawAsync(countriesSqlScript);
            }
        }

        private async Task CheckData()
        {
            if (!_context.employees.Any())
            {
                var employess = File.ReadAllText("Data\\DataEmployees.sql");
                await _context.Database.ExecuteSqlRawAsync(employess);
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.countries.Any())
            {
                _context.countries.Add(new Country
                {
                    Name = "Colombia",
                    States = [
                        new State()
                        {
                            Name = "Antioquia",
                            Cities = [
                                new City() { Name = "Medellín"},
                                new City() { Name = "Itagui"},
                                new City() { Name = "Envigado"},
                                new City() { Name = "Bello"},
                                new City() { Name = "Rionegro"}
                            ]
                        },
                        new State()
                        {
                            Name = "Bogotá",
                            Cities = [
                                new City() { Name = "Usaquen"},
                                new City() { Name = "Chapinero"},
                                new City() { Name = "Santa fe"},
                                new City() { Name = "Usme"},
                                new City() { Name = "Bosa"}
                            ]
                        }
                    ],
                });
                _context.countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = [
                        new State()
                        {
                            Name = "Florida",
                            Cities = [
                                new City() { Name = "Orlando" },
                                new City() { Name = "Miami" },
                                new City() { Name = "Tampa" },
                                new City() { Name = "Fort Lauderdale" },
                                new City() { Name = "Key Wets" }
                            ]
                        },
                        new State() {
                            Name = "Texas",
                            Cities = [
                                new City() { Name = "Houston" },
                                new City() { Name = "San antonio" },
                                new City() { Name = "Dallas" },
                                new City() { Name = "Austin" },
                                new City() { Name = "El paso" },
                            ]
                        }
                    ]
                });
            }

            await _context.SaveChangesAsync();
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
