﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardIndex.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthDateText => BirthDate.ToShortDateString();

        public string Position { get; set; }

        public string Department { get; set; }

        public DateTime EmploymentDate { get; set; }

        public string EmploymentDateText => EmploymentDate.ToShortDateString();
    }
}
