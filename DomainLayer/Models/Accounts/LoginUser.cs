using System;

namespace DomainLayer.Models.Accounts
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public int MinistryOrDepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public bool isActive { get; set; }
        public int? CreatorId { get; set; }

    }
    public class authenticuserdata
    {
        public int id { get; set; }
        public string name { get; set; }
        public int usertype { get; set; }
        public string token { get; set; }
        public int statuscode { get; set; }
        public string statusmessage { get; set; }
    }
}
