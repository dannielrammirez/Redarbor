using APIRedarbor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APIRedarbor.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetData<T>(string str);
        ICollection<T> GetDataList<T>(string str);
        int ExecuteData(string str, bool isCreate = false, params IDataParameter[] sqlParams);
    }
}
