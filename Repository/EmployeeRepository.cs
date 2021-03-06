using APIRedarbor.Enums;
using APIRedarbor.Models;
using APIRedarbor.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIRedarbor.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Employee CreateEmployee(Employee employee)
        {
            string query = "INSERT INTO Employee VALUES " +
               "(@CompanyId, @CreatedOn, @DeletedOn, @Email, @Fax, @Name, @LastLogin, @Password, @PortalId, @RoleId, @StatusId, @Telephone, @UpdatedOn, @Username);";

            var parameters = new IDataParameter[]
            {
                new SqlParameter("@CompanyId", employee.CompanyId),
                new SqlParameter("@CreatedOn", employee.CreatedOn),
                new SqlParameter("@DeletedOn", employee.DeletedOn),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Fax", employee.Fax),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@LastLogin", employee.Lastlogin),
                new SqlParameter("@Password", employee.Password),
                new SqlParameter("@PortalId",employee.PortalId),
                new SqlParameter("@RoleId",employee.RoleId),
                new SqlParameter("@StatusId",employee.StatusId),
                new SqlParameter("@Telephone",employee.Telephone),
                new SqlParameter("@UpdatedOn",employee.UpdatedOn),
                new SqlParameter("@Username",employee.Username)
            };

            employee.Id = ExecuteData(query, isCreate: true, parameters);

            return employee;
        }

        public bool DeleteEmployeeById(int idEmployee)
        {
            bool resp;

            var employee = GetEmployeeById(idEmployee);
            employee.StatusId = (int)EnumStatus.Eliminado;
            UpdateEmployee(employee);
            resp = true;

            return resp;
        }

        public bool DeleteDBEmployeeById(int idEmployee)
        {
            bool resp;
            int successTran = 0;

            string query = "DELETE Employee WHERE Id = @Id";

            var parameters = new IDataParameter[] { new SqlParameter("@Id", idEmployee) };

            successTran = ExecuteData(query, isCreate: false, parameters);
            resp = successTran > 0;

            return resp;
        }

        public bool ExistEmployee(int idEmployee)
        {
            string query = $"SELECT * FROM Employee where Id = {idEmployee};";

            var employee = GetData<Employee>(query);

            return employee != null;
        }

        public ICollection<Employee> GetAllEmployees()
        {
            string query = "SELECT * FROM Employee";
            var listEmployees = GetDataList<Employee>(query);

            return listEmployees;
        }

        public Employee GetEmployeeById(int idEmployee)
        {
            string query = $"SELECT * FROM Employee where Id = {idEmployee};";

            var employe = GetData<Employee>(query);

            return employe;
        }

        public bool UpdateEmployee(Employee employee)
        {
            bool resp = false;

            string query = "UPDATE Employee" +
                " SET CompanyId = @CompanyId" +
                ", CreatedOn = @CreatedOn" +
                ", DeletedOn = @DeletedOn" +
                ", Email = @Email" +
                ", Fax = @Fax" +
                ", Name = @Name" +
                ", LastLogin = @LastLogin" +
                ", Password = @Password" +
                ", PortalId = @PortalId" +
                ", RoleId = @RoleId" +
                ", StatusId = @StatusId" +
                ", Telephone = @Telephone" +
                ", UpdatedOn = @UpdatedOn" +
                ", Username = @Username" +
                " WHERE Id = @Id";

            var parameters = new IDataParameter[]
            {
                new SqlParameter("@Id", employee.Id),
                new SqlParameter("@CompanyId", employee.CompanyId),
                new SqlParameter("@CreatedOn", employee.CreatedOn),
                new SqlParameter("@DeletedOn", employee.DeletedOn),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Fax", employee.Fax),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@LastLogin", employee.Lastlogin),
                new SqlParameter("@Password", employee.Password),
                new SqlParameter("@PortalId",employee.PortalId),
                new SqlParameter("@RoleId",employee.RoleId),
                new SqlParameter("@StatusId",employee.StatusId),
                new SqlParameter("@Telephone",employee.Telephone),
                new SqlParameter("@UpdatedOn",employee.UpdatedOn),
                new SqlParameter("@Username",employee.Username)
            };

            if (ExecuteData(query, isCreate:false, parameters) > 0)
                resp = true;

            return resp;
        }
    }
}