using APIRedarbor.Models;
using APIRedarbor.Repository.IRepository;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIRedarbor.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public static string sqlDataSource;
        public Repository()
        {
            sqlDataSource = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Redarbor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public int ExecuteData(string str, bool isCreate, params IDataParameter[] sqlParams)
        {
            int rowId = -1;

            if(isCreate) str += " SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(str, conn))
                    {
                        if (sqlParams != null)
                        {
                            foreach (IDataParameter para in sqlParams)
                            {
                                cmd.Parameters.Add(para);
                            }

                            rowId = isCreate ? Convert.ToInt32(cmd.ExecuteScalar()) : cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return rowId;
        }

        public ICollection<T1> GetDataList<T1>(string str)
        {
            ICollection<T1> result = default(ICollection<T1>);

            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                SqlCommand command = new SqlCommand(str, connection);
                try
                {
                    using (var reader = connection.QueryMultiple(str))
                    {
                        result = reader.Read<T1>().ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }

        public T1 GetData<T1>(string str)
        {
            T1 result = default(T1);

            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                SqlCommand command = new SqlCommand(str, connection);
                try
                {
                    using (var reader = connection.QueryMultiple(str))
                    {
                        result = reader.Read<T1>().FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}
