using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.Configuration.Office
{
    public class GetOfficeVM
    {
        public int ID { get; set; }
        public int ParentId { get; set; }
        public int MinistryOrDepartmentId { get; set; }
        public string MinistryOrDepartmentName { get; set; }
        public string NameE { get; set; }
        public string NameB { get; set; }
        public string Address { get; set; }
        public bool isActive { get; set; }
    }
}
