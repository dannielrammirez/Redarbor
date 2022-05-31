using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;

namespace APIRedarbor.Models
{
    public class Employee
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int companyId;
        public int CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }

        private DateTime createdOn;
        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }

        private DateTime? deletedOn;
        public DateTime? DeletedOn
        {
            get { return deletedOn; }
            set { deletedOn = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string fax;
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime? lastlogin;
        public DateTime? Lastlogin
        {
            get { return lastlogin; }
            set { lastlogin = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private int portalId;
        public int PortalId
        {
            get { return portalId; }
            set { portalId = value; }
        }

        private int roleId;
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        private int statusId;
        public int StatusId
        {
            get { return statusId; }
            set { statusId = value; }
        }

        private string telephone;
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        private DateTime? updatedOn;
        public DateTime? UpdatedOn
        {
            get { return updatedOn; }
            set { updatedOn = value; }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
