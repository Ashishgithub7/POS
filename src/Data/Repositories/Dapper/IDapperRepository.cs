using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Dapper
{
    public interface IDapperRepository
    {
        Task<int> ExecuteScalarAsync(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.StoredProcedure);

        Task<int> ExecuteAsync(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.StoredProcedure);

        Task<List<T>> QueryAsync<T>(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.StoredProcedure) where T : class;

        Task<T> QueryFirstOrDefaultAsync<T>(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.StoredProcedure) where T : class;

        Task<T> QuerySingleOrDefaultAsync<T>(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.StoredProcedure) where T : class;
    }
}
