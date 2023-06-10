using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFECMS.Domain.ViewModel.Permission
{
    public class PermissionSearchVM
    {
        public string Name { get; set; }
        public int MinistryOrDepartmentID { get; set; }
        public int OfficeID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
