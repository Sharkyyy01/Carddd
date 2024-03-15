using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardIndex.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string BirthDateText
        {
            get => BirthDate.ToString();
            set => BirthDate = DateTime.Parse(value);
        }

        public DateTime EmploymentDate { get; set; }
        public string EmploymentDateText
        {
            get => EmploymentDate.ToString();
            set => EmploymentDate = DateTime.Parse(value);
        }

        public string Position { get; set; }

        public string Department { get; set; }
    }
}
