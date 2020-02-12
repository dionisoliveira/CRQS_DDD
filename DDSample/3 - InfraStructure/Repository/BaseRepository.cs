

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DDDSample.InfraStructure.Repository
{
    public class BaseRepository
    {
        #region Fields
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        #endregion

        #region Properties

        public IDbConnection Connetion
        {
            get
            {
                return new SqlConnection(
               _config.GetConnectionString(_connectionString));
            }
        }
        #endregion

        public BaseRepository([FromServices]IConfiguration config, string connection)
        {
            _config = config;
            _connectionString = connection;
        }

    }
}
