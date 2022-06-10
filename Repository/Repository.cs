using APIRedarbor.Repository.IRepository;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace APIRedarbor.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _sqlDataSource;
        private readonly IConfiguration _configuration;
        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
        }

        public int ExecuteData(string str, bool isCreate, params IDataParameter[] sqlParams)
        {
            int rowId = -1;

            if(isCreate) str += " SELECT SCOPE_IDENTITY()";

            using (SqlConnection conn = new(_sqlDataSource))
            {
                conn.Open();
                using SqlCommand cmd = new(str, conn);
                if (sqlParams != null)
                {
                    foreach (IDataParameter para in sqlParams)
                    {
                        cmd.Parameters.Add(para);
                    }

                    rowId = isCreate ? Convert.ToInt32(cmd.ExecuteScalar()) : cmd.ExecuteNonQuery();
                }
            }

            return rowId;
        }

        public ICollection<T1> GetDataList<T1>(string str)
        {
            ICollection<T1> result = default;

            using (SqlConnection connection = new(_sqlDataSource))
            {
                using var reader = connection.QueryMultiple(str);
                result = reader.Read<T1>().ToList();
            }

            return result;
        }

        public T1 GetData<T1>(string str)
        {
            T1 result = default;

            using (SqlConnection connection = new(_sqlDataSource))
            {
                using var reader = connection.QueryMultiple(str);
                result = reader.Read<T1>().FirstOrDefault();
            }

            return result;
        }
    }
}
