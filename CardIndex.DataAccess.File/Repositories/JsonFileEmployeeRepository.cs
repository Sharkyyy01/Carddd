using CardIndex.Core.Entities;
using CardIndex.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.Json;
using System.Threading.Tasks;
//using System.Xml;
using Newtonsoft.Json;

namespace CardIndex.DataAccess.File.Repositories
{
    public class JsonFileEmployeeRepository : IEmployeeRepository
    {
        public string FileName { get; set; }

        public IEnumerable<Employee> GetAll()
        {
            using (var sr = new StreamReader(FileName))
            {
                var serializer = new JsonSerializer();
                return (List<Employee>)serializer.Deserialize(sr, typeof(List<Employee>));
            }
        }

        public void SaveAll(IEnumerable<Employee> employees)
        {
            using (var sw = new StreamWriter(FileName))
            {
                var serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(sw, employees);
            }
        }
    }
}
