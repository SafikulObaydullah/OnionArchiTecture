using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFECMS.Domain.ViewModel.Permission
{
    public class UserOfficePermissionVM
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public int PermissionofficeId { get; set; }
        public bool IsPermission { get; set; }
    }
}
