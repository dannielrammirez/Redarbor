using System.Collections.Generic;
using System.Data;

namespace APIRedarbor.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T1 GetData<T1>(string str);
        ICollection<T1> GetDataList<T1>(string str);
        int ExecuteData(string str, bool isCreate = false, params IDataParameter[] sqlParams);
    }
}