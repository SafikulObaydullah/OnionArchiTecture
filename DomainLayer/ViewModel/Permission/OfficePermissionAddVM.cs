using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.Permission
{
    public class OfficePermissionAddVM
    {

        public bool isActive { get; set; }
        public int Creator { get; set; }
        public IEnumerable<officeVM> childList { get; set; }
    }
    public class officeVM
    {
        public int userId { get; set; }
        public int officeId { get; set; }
    }
}
