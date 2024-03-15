using CardIndex.Core.Entities;
using CardIndex.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardIndex.DataAccess.File.Repositories
{
    public class BinaryFileEmployeeRepository : IEmployeeRepository
    {
        public string FileName { get; set; }

        public IEnumerable<Employee> GetAll()
        {
            using (var br = new BinaryReader(System.IO.File.Open(FileName, FileMode.Open)))
            {
                var result = new List<Employee>();

                while (br.PeekChar() > -1)
                {
                    var id = br.ReadInt32();

                    //var firstName = br.ReadString();
                    var firstNameByteCount = br.ReadInt32();
                    var firstNameBytes = br.ReadBytes(firstNameByteCount);
                    var firstName = Encoding.UTF8.GetString(firstNameBytes);

                    var middleName = br.ReadString();
                    var lastName = br.ReadString();
                    var ticks = br.ReadInt64();
                    var birthDate = new DateTime(ticks);
                    var position = br.ReadString();
                    var division = br.ReadString();
                    ticks = br.ReadInt64();
                    var employmentDate = new DateTime(ticks);

                    result.Add(new Employee
                    {
                        Id = id,
                        FirstName = firstName,
                        MiddleName = middleName,
                        LastName = lastName,
                        BirthDate = birthDate,
                        Position = position,
                        Department = division,
                        EmploymentDate = employmentDate,
                    });
                }

                return result;
            }
        }

        public void SaveAll(IEnumerable<Employee> employees)
        {
            using (var bw = new BinaryWriter(System.IO.File.Open(FileName, FileMode.Create)))
            {
                foreach (var employee in employees)
                {
                    bw.Write(employee.Id);

                    //bw.Write(employee.FirstName);
                    var firstNameBytes = Encoding.UTF8.GetBytes(employee.FirstName);
                    bw.Write(firstNameBytes.Length);
                    bw.Write(firstNameBytes);

                    bw.Write(employee.MiddleName);
                    bw.Write(employee.LastName);
                    bw.Write(employee.BirthDate.Ticks);
                    bw.Write(employee.Position);
                    bw.Write(employee.Department);
                    bw.Write(employee.EmploymentDate.Ticks);
                }
            }
        }
    }
}
