using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.User
{
    public class UserPermissionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int OfficeId { get; set; }
        public int MinistryOrDepartmentId { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
    }
}
