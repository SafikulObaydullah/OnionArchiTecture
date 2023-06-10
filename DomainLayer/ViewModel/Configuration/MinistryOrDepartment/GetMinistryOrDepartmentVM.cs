﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.Configuration.MinistryOrDepartment
{
    public class GetMinistryOrDepartmentVM
    {
        public int ID { get; set; }
        public string NameE { get; set; }
        public string NameB { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
        public bool isDepartment { get; set; }

    }
}
