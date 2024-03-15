using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardIndex.Business.Models;
using CardIndex.Core.Entities;
using CardIndex.DataAccess.File.Repositories;
using CardIndex.DataAccess.Postgres.Repositories;


namespace CardIndex.Business.Services
{
    public class EmployeeService
    {
        private readonly EmployeeStorage _storage = new EmployeeStorage();

        private EmployeeRepository _employeeRepository = new EmployeeRepository();


        public EmployeeService() 
        {
            InitializeStorage();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _storage.Employees;
        }

        private void InitializeStorage()
        {
            /*_storage.Employees.Add(new Employee
            {
                Id = 1,
                FirstName = "Андрей",
                MiddleName = "Григорьевич",
                LastName = "Захаров",
                BirthDate = new DateTime(1985, 11, 8),
                Position = "Руководитель проекта",
                Department = "Отдел разработки",
                EmploymentDate = new DateTime(2019, 7, 15),
            });

            _storage.Employees.Add(new Employee
            {
                Id = 2,
                FirstName = "Людмила",
                MiddleName = "Алексеевна",
                LastName = "Фролова",
                BirthDate = new DateTime(1978, 3, 11),
                Position = "Бизнес-аналитик",
                Department = "Отдел анализа",
                EmploymentDate = new DateTime(2020, 2, 3),
            });

            _storage.Employees.Add(new Employee
            {
                Id = 3,
                FirstName = "Вера",
                MiddleName = "Владимировна",
                LastName = "Тищенко",
                BirthDate = new DateTime(1989, 6, 10),
                Position = "Руководитель группы",
                Department = "Отдел тестирования",
                EmploymentDate = new DateTime(2021, 11, 18),
            });*/

            var employees = _employeeRepository.GetAll();

            if (employees == null)
                return;

            foreach (var employee in employees)
            {
                _storage.Employees.Add(new Employee
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName,
                    BirthDate = employee.BirthDate,
                    Position = employee.Position,
                    Department = employee.Department,
                    EmploymentDate = employee.EmploymentDate,
                });
            }

            EmployeeStorage.MaxID = _storage.Employees.Max(e => e.Id);
        }

        public void SaveEmployee(Employee employee)
        {
            if (employee.Id == 0)
            {
                _employeeRepository.Insert(employee);

                EmployeeStorage.MaxID++;
                employee.Id = EmployeeStorage.MaxID;
                _storage.Employees.Add(employee);
            }
            else
            {
                var existingEmployee = _storage.Employees.FirstOrDefault(e => e.Id == employee.Id);
                if (existingEmployee == null)
                {
                    throw new IndexOutOfRangeException();
                }

                _employeeRepository.Update(employee);

                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.MiddleName = employee.MiddleName;
                existingEmployee.BirthDate = employee.BirthDate;
                existingEmployee.Position = employee.Position;
                existingEmployee.Department = employee.Department;
                existingEmployee.EmploymentDate = employee.EmploymentDate;
            }
        }

        public void Delete(int employeeId)
        {
            var existingEmployee = _storage.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (existingEmployee == null)
            {
                throw new IndexOutOfRangeException();
            }

            _employeeRepository.Delete(employeeId);

            _storage.Employees.Remove(existingEmployee);
        }

        public void Save(string filename)
        {
            var repository = new FileEmployeeRepositoryFactory().CreateRepository(filename);
            if (repository == null)
            {
                return;
            }

            repository.SaveAll(_storage.Employees);
        }

        public void Open(string filename)
        {
            var repository = new FileEmployeeRepositoryFactory().CreateRepository(filename);
            if (repository == null)
            {
                return;
            }

            _storage.Employees.Clear();
            _storage.Employees.AddRange(repository.GetAll());
            EmployeeStorage.MaxID = _storage.Employees.Any() ? _storage.Employees.Max(e => e.Id) : 0;
        }
    }
}
