using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.DataAccess
{
    public class DbConnection
    {
        private readonly IConfiguration _config;
        private readonly IMongoDatabase _db;
        private string _connectionId = "MongoDB";
        public int DbName { get; private set; }
        public string CategoryCollectionName { get; private set; } = "categories";

        public DbConnection(IConfiguration config)
        {
            _config = config;
        }
    }
}
